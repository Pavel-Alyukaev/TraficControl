using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Cuda;
using Emgu.CV.Face;



namespace TraficControl
{
    public partial class Form1 : Form
    {
        private VideoCapture CamVideo = null;
        public static int WindowsSize = 20;
        public static Double ScaleIncreaseRate = 1.1;
        public static int MinNeighbors = 10;



        public Form1()
        {
            InitializeComponent();
        }

        

        private void MoveVideo(object sender, EventArgs e)
        {
            
            IImage image1= CamVideo.QueryFrame();
            List<Rectangle> faces = new List<Rectangle>();
            Detect(image1, @"cascade\haarcascade_frontalface_default.xml", faces);
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image1, face, new Bgr(Color.Red).MCvScalar, 2);
            }
            imageBox1.Image = image1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                CamVideo = new VideoCapture();
            }
            catch (NullReferenceException except)
            {
                label1.Visible = true;
                label1.Text = except.Message;
                return;
            }


            Application.Idle += MoveVideo;
        }

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
                           ScaleIncreaseRate,
                           MinNeighbors,
                           new Size( WindowsSize, WindowsSize));

                        faces.AddRange(facesDetected);

                    }
                }
            }
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CamVideo!=null)            
                CamVideo.Dispose();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
   
        private void детекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParamDetect Detect = new ParamDetect();
            Detect.ShowDialog();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
