using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trei3Dcube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       //CREATE A 3D CUBE ISO WHO CAN BE TOTATED 

        public class cub {

            Graphics ig;
            Pen pen1 = new Pen(Color.Yellow);
            Pen pen0 = new Pen(Color.Blue);
            
            public float rad = (float)(180 / Math.PI);
            public float rez = 360.0f / 4;
            public int dim = 50;
            public int pozy = 250;
            public float cx;
            public float cy;
            public float px;
            public float py;
            public float x;
            public float y;
            public float z;
            public float xdim;
            public float ydim;
            public float zdim;

            public float worldAngle = 10.0f;

            //is a pointer
            public Form forma;

            public static List<float> pointsofsquare1 = new List<float>();
            public static List<float> pointsofsquare2 = new List<float>();

            public void creategrafics(Form f) {
                this.forma = f;
                ig = f.CreateGraphics();
            }

            public float distantaintredouapuncte2dxy(float x1, float y1, float x2, float y2)
            {
                float c;
                c = (float)Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
                return c;
            }


            public cub(float px, float py, float pz, float pxdim, float pydim, float pzdim)
                {
                
                x = px;
                y = py;
                z = pz;
                xdim = pxdim;
                ydim = pydim;
                zdim = pzdim;
                }

            public void drawLinesVerticals()
            {
                for (int i = 0; i < rez * 2; i += 2)
                {
                    try {
                        ig.DrawLine(pen0, pointsofsquare1[i], pointsofsquare1[i + 1], pointsofsquare2[i], pointsofsquare2[i + 1]);
                    }
                    catch { }
                }
            }

            public void deleteAllPointsFromLists()
            { 
                pointsofsquare1.Clear();
                pointsofsquare2.Clear();
            }
            public void calculate()
            {
                this.dc1();
                this.dc2();
            }
            public void draw()
            {
               
               
                try
                {
                    this.deleteAllPointsFromLists();
                }
                catch { }
                calculate();    
                this.drawLinesVerticals();
            }
          
            public void dc1()
            {
                py = (float)((Math.Sin((1+ worldAngle) / rad))) * ydim + y;
                px = (float)((Math.Cos((1 + worldAngle) / rad))) * xdim + x;


                for (float i = 1.0f; i < 360.0f + rez; i += rez)
                {


                    cy = (float)((Math.Sin((i + worldAngle) / rad))) * ydim + y;
                    cx = (float)((Math.Cos((i + worldAngle) / rad))) * xdim + x;

                    pointsofsquare1.Add(cx);
                    pointsofsquare1.Add(cy);

                    ig.DrawLine(pen0, px, py, cx, cy);

                    px = cx;
                    py = cy;
                }
            }

            public void clear()
            {
                ig.Clear(forma.BackColor);
            }

            public void dc2()
            {
                py = (float)((Math.Sin((1 + worldAngle) / rad))) * ydim + y-ydim ;
                px = (float)((Math.Cos((1 + worldAngle) / rad))) * xdim + x-xdim / 2;


                for (float i = 1.0f; i < 360.0f + rez; i += rez)
                {


                    cy = (float)((Math.Sin((i + worldAngle) / rad))) * ydim + y - ydim;
                    cx = (float)((Math.Cos((i + worldAngle) / rad))) * xdim + x - xdim/2;

                    pointsofsquare2.Add(cx);
                    pointsofsquare2.Add(cy);

                    ig.DrawLine(pen0, px, py, cx, cy);

                    px = cx;
                    py = cy;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cubul.creategrafics(this);
            cubul.draw();

        }


        public cub cubul = new cub(250,250,250,50,50,50);

        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cubul.worldAngle += 5 ;
            cubul.clear();
            cubul.draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cubul.worldAngle -= 5;
            cubul.clear();
            cubul.draw();
        }
    }
}
