﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private VideoCapture video = new VideoCapture();

        private void MoveVideo(object sender, EventArgs e)
        {
            
            IImage image1= video.QueryFrame();
            imageBox1.Image = image1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += MoveVideo;
        }
    }
}
