using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace HandGestureRecognition.SkinDetector
{
    // abstract class IColorSkinDetector được tạo ra để phục vụ cho các lớp khác.
    public abstract class IColorSkinDetector
    {
       public abstract Image<Gray, Byte> DetectSkin(Image<Bgr, Byte> Img, IColor min, IColor max);                
    }
}
