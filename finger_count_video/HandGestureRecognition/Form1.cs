using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV.Structure;
using Emgu.CV;
using HandGestureRecognition.SkinDetector;

namespace HandGestureRecognition
{
    public partial class Form1 : Form
    {

        IColorSkinDetector skinDetector;

        Image<Bgr, Byte> currentFrame;        // biến currentFrame để chỉ khung hiện tại
        Image<Bgr, Byte> currentFrameCopy;    // biến currentFramecompy để chỉ khung tương thích trên frame  phản chiếu

        Capture grabber;                   // biến grabber để có được hình ảnh từ video file or camera
        AdaptiveSkinDetector detector;

        // một vài biến để xác định một số thuộc tính của video file
        int frameWidth;   // độ rộng của frame
        int frameHeight;  // chiều cao của frame

        Hsv hsv_min;    // ngưỡng dưới và ngưỡng trên của hsv  
        Hsv hsv_max;
        Ycc YCrCb_min;  // ngưỡng dưới và ngưỡng trên của YCrCB
        Ycc YCrCb_max;

        // khai báo 1 số biến để chỉ các điểm giới hạn và các điểm khuyết trên bàn tay
        Seq<Point> hull;
        Seq<Point> filteredHull;
        Seq<MCvConvexityDefect> defects;
        MCvConvexityDefect[] defectArray;
        
        MCvBox2D box; // biến  khởi tạo 1 khung (hình chữ nhật)
      

        // constructor khởi tạo giá trị
        public Form1()
        {
            InitializeComponent();
            grabber = new Emgu.CV.Capture(@".\..\..\..\hao.mpg");  // có được từ video file nhờ sử dụng biến grabber            
            grabber.QueryFrame(); // nhận khung hình từ video file
            frameWidth = grabber.Width;    // thiet lap kich thuoc cua khung lay tu kich thuoc cua video file da co
            frameHeight = grabber.Height;
            detector = new AdaptiveSkinDetector(1, AdaptiveSkinDetector.MorphingMethod.NONE); // nhận diện skin
            /* xác định ngưỡng trên và ngưỡng dưới của hsv and YCrCB color space 
             có thể điều chỉnh để phù hơp với video file  */
            hsv_min = new Hsv(0, 45, 0);
            hsv_max = new Hsv(20, 255, 255);
            YCrCb_min = new Ycc(0, 131, 80);
            YCrCb_max = new Ycc(255, 185, 135);
            box = new MCvBox2D();
            

            // gắn thêm FrameGrabber vào Eventhandler để truy cập vào hsv frame and YCrCB frame
            Application.Idle += new EventHandler(FrameGrabber);
           
        }

        // truy cập vào khung tham chiếu từ video file
        void FrameGrabber(object sender, EventArgs e)
        {
            currentFrame = grabber.QueryFrame();
            if (currentFrame != null)
            {
                currentFrameCopy = currentFrame.Copy(); // có được khung ánh xạ của bàn tay
                // sử dụng YcrCbskinDetector để nhận diện skin
                skinDetector = new YCrCbSkinDetector();

                Image<Gray, Byte> skin = skinDetector.DetectSkin(currentFrameCopy, YCrCb_min, YCrCb_max);

                ExtractContourAndHull(skin);

                DrawAndComputeFingersNum();

                imageBoxSkin.Image = skin;
                imageBoxFrameGrabber.Image = currentFrame;
            }
        }
        // class MemStorage() để tạo bộ nhớ mở cho openCV
        MemStorage storage = new MemStorage();
        // chiết xuất ra đường viền bao bọc bàn tay
        private void ExtractContourAndHull(Image<Gray, byte> skin)
        {            
            {
                // tìm đường viền bao bọc bàn tay
                Contour<Point> contours = skin.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_LIST, storage);
                // biggest contour chính là đường biểu thị đường bao bọc bàn tay
                Contour<Point> biggestContour = null;
                // class contour() đê taọ đường viền, sử dụng bộ nhớ storage
                Double Result1 = 0;
                Double Result2 = 0;
                while (contours != null)
                {
                    Result1 = contours.Area;
                    if (Result1 > Result2)
                    {
                        Result2 = Result1;
                        biggestContour = contours;
                    }
                    contours = contours.HNext;
                }

                if (biggestContour != null)
                {
                    // class ApproxPoly(Double, MemStorage) xấp xỉ 1 đường cong và trả về kết quả xấp xỉ
                    Contour<Point> currentContour = biggestContour.ApproxPoly(biggestContour.Perimeter * 0.0025, storage);
                    // dung màu xanh là cây để biểu diễn đường viền bao tay
                    currentFrame.Draw(currentContour, new Bgr(Color.LimeGreen), 2);

                    biggestContour = currentContour;


                    hull = biggestContour.GetConvexHull(Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);
                    box = biggestContour.GetMinAreaRect();
                    PointF[] points = box.GetVertices();
                   

                    Point[] ps = new Point[points.Length];
                    for (int i = 0; i < points.Length; i++)
                        ps[i] = new Point((int)points[i].X, (int)points[i].Y);

                    currentFrame.DrawPolyline(hull.ToArray(), true, new Bgr(200, 125, 75), 2);
                    currentFrame.Draw(new CircleF(new PointF(box.center.X, box.center.Y), 3), new Bgr(200, 125, 75), 2);
           
                    filteredHull = new Seq<Point>(storage);
                    for (int i = 0; i < hull.Total; i++)
                    {
                        if (Math.Sqrt(Math.Pow(hull[i].X - hull[i + 1].X, 2) + Math.Pow(hull[i].Y - hull[i + 1].Y, 2)) > box.size.Width / 10)
                        {
                            filteredHull.Push(hull[i]);
                        }
                    }

                    defects = biggestContour.GetConvexityDefacts(storage, Emgu.CV.CvEnum.ORIENTATION.CV_CLOCKWISE);

                    defectArray = defects.ToArray();
                }
            }
        }
        // ve va dem so luong ngon tay
     //   int fingerNum = 0;
        private void DrawAndComputeFingersNum()
        {
            
            int fingerNum = 0;

            #region defects drawing
            for (int i = 0; i < defects.Total; i++)
            {
                LoadListView();
                // khởi tạo 3 điểm startpoint , depthpoint và endpoint của convexity defect
                // hàm PointF(single,single) để khởi tạo 1 điểm với các  tọa độ cụ thể 
                PointF startPoint = new PointF((float)defectArray[i].StartPoint.X,
                                                (float)defectArray[i].StartPoint.Y);

                PointF depthPoint = new PointF((float)defectArray[i].DepthPoint.X,
                                                (float)defectArray[i].DepthPoint.Y);

                PointF endPoint = new PointF((float)defectArray[i].EndPoint.X,
                                                (float)defectArray[i].EndPoint.Y);
                // hàm 	LineSegment2D(Point2D<T>, Point2D<T>) để tạo 1 đoạn thẳng với điểm đầu và điểm cuối cụ thể 

                LineSegment2D startDepthLine = new LineSegment2D(defectArray[i].StartPoint, defectArray[i].DepthPoint);

                LineSegment2D depthEndLine = new LineSegment2D(defectArray[i].DepthPoint, defectArray[i].EndPoint);

                // hàm  CircleF(PointF, Single) để tạo 1 vòng tròn với bán kính cụ thể

                CircleF startCircle = new CircleF(startPoint, 5f);

                CircleF depthCircle = new CircleF(depthPoint, 5f);

                CircleF endCircle = new CircleF(endPoint, 5f);

                
                
                    // nếu đoạn nối giữa start point và end point đủ lớn thì sẽ được tính là 1 ngón tay
                    if ((startCircle.Center.Y < box.center.Y || depthCircle.Center.Y < box.center.Y) && (startCircle.Center.Y < depthCircle.Center.Y) && (Math.Sqrt(Math.Pow(startCircle.Center.X - depthCircle.Center.X, 2) + Math.Pow(startCircle.Center.Y - depthCircle.Center.Y, 2)) > box.size.Height / 6.5))
                    {
                        fingerNum++;
                        // vẽ đoạn màu da cam để xác định số ngón tay từ startpoint đến depthpoint
                        currentFrame.Draw(startDepthLine, new Bgr(Color.Orange), 2);                     
                        // currentFrame.Draw(depthEndLine, new Bgr(Color.Magenta), 2);
                    }
                


                currentFrame.Draw(startCircle, new Bgr(Color.Red), 2); // start point biểu diễn bằng nốt màu đỏ
                currentFrame.Draw(depthCircle, new Bgr(Color.Yellow), 5); // depthpoint biểu diễn bằng nốt màu vàng
                                                                          // currentFrame.Draw(endCircle, new Bgr(Color.DarkBlue), 4); // endpoint biểu diễn bằng nốt màu darkblue
            }
            #endregion


            // hàm MCvFont(FONT, Double, Double) để tạo phông chữ (hiể thị số lượng ngón tay), quy mô theo chiều ngang và dọc
            MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_DUPLEX, 5d, 5d);
            currentFrame.Draw(fingerNum.ToString(), ref font, new Point(50, 150), new Bgr(Color.White));
            
            void LoadListView()
            {
                Lsv.Items.Add(fingerNum.ToString());
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("do you want to quit!", "Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
                Application.Exit();
        }
    }
}