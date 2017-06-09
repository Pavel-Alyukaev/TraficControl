using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using Emgu.CV.Face;

namespace TraficControl
{
    class DetectFace
    {
        public static void Detect(
        IInputArray image, String faceFileName, List<Rectangle> faces)
        {
            using (InputArray iaImage = image.GetInputArray())
            {
                using (CascadeClassifier face = new CascadeClassifier(faceFileName))
                {    
                    using (UMat ugray = new UMat())    
                    {    
                        CvInvoke.CvtColor(image, ugray, ColorConversion.Bgr2Gray);    

                        CvInvoke.EqualizeHist(ugray, ugray);    

                        Rectangle[] facesDetected = face.DetectMultiScale(    
                           ugray,    
                           1.2,    
                           10,    
                           new Size(20, 20));    

                        faces.AddRange(facesDetected);    

                    }    
                }    
            }
        }
    }
}
