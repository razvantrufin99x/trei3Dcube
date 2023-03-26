using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        bool ismousdown = false;
        int posxm = 0;
        int posym = 0;
        int preposxm = 0;
        int preposym = 0;

        public float thisworldAngle = 10.0f;

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

            public  List<float> pointsofsquare1 = new List<float>(100);
            public  List<float> pointsofsquare2 = new List<float>(100);

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
            public cub(float px, float py, float pz, float pxdim, float pydim, float pzdim, float prez)
            {

                x = px;
                y = py;
                z = pz;
                xdim = pxdim;
                ydim = pydim;
                zdim = pzdim;
                rez = prez;
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

            public void fillFaces()
            {

                Point p0 = new Point((int)pointsofsquare1[0], (int)pointsofsquare1[1]);
                Point p1 = new Point((int)pointsofsquare1[2], (int)pointsofsquare1[3]);
                Point p2 = new Point((int)pointsofsquare1[4], (int)pointsofsquare1[5]);
                Point p3 = new Point((int)pointsofsquare1[6], (int)pointsofsquare1[7]);

                Point[] puncte = new Point[4];
                puncte[0] = p0;
                puncte[1] = p1;
                puncte[2] = p2;
                puncte[3] = p3;

                ig.FillPolygon(new SolidBrush(Color.AliceBlue), puncte);

                Point p0b = new Point((int)pointsofsquare2[0], (int)pointsofsquare2[1]);
                Point p1b = new Point((int)pointsofsquare2[2], (int)pointsofsquare2[3]);
                Point p2b = new Point((int)pointsofsquare2[4], (int)pointsofsquare2[5]);
                Point p3b = new Point((int)pointsofsquare2[6], (int)pointsofsquare2[7]);

                Point[] puncteb = new Point[4];
                puncteb[0] = p0b;
                puncteb[1] = p1b;
                puncteb[2] = p2b;
                puncteb[3] = p3b;

                ig.FillPolygon(new SolidBrush(Color.Sienna), puncteb);



                Point p0c = new Point((int)pointsofsquare1[0], (int)pointsofsquare1[1]);
                Point p1c = new Point((int)pointsofsquare2[0], (int)pointsofsquare2[1]);
                Point p2c = new Point((int)pointsofsquare2[2], (int)pointsofsquare2[3]);
                Point p3c = new Point((int)pointsofsquare1[2], (int)pointsofsquare1[3]);

                Point[] punctec = new Point[4];
                punctec[0] = p0c;
                punctec[1] = p1c;
                punctec[2] = p2c;
                punctec[3] = p3c;

                ig.FillPolygon(new SolidBrush(Color.Silver), punctec);
               
                Point p0d = new Point((int)pointsofsquare1[2], (int)pointsofsquare1[3]);
                Point p1d = new Point((int)pointsofsquare2[2], (int)pointsofsquare2[3]);
                Point p2d = new Point((int)pointsofsquare2[4], (int)pointsofsquare2[5]);
                Point p3d = new Point((int)pointsofsquare1[4], (int)pointsofsquare1[5]);

                Point[] puncted = new Point[4];
                puncted[0] = p0d;
                puncted[1] = p1d;
                puncted[2] = p2d;
                puncted[3] = p3d;

                ig.FillPolygon(new SolidBrush(Color.Snow), puncted);

                Point p0e = new Point((int)pointsofsquare1[4], (int)pointsofsquare1[5]);
                Point p1e = new Point((int)pointsofsquare2[4], (int)pointsofsquare2[5]);
                Point p2e = new Point((int)pointsofsquare2[6], (int)pointsofsquare2[7]);
                Point p3e = new Point((int)pointsofsquare1[6], (int)pointsofsquare1[7]);

                Point[] punctee = new Point[4];
                punctee[0] = p0e;
                punctee[1] = p1e;
                punctee[2] = p2e;
                punctee[3] = p3e;

                ig.FillPolygon(new SolidBrush(Color.Tan), punctee);
 
                Point p0f = new Point((int)pointsofsquare1[6], (int)pointsofsquare1[7]);
                Point p1f = new Point((int)pointsofsquare2[6], (int)pointsofsquare2[7]);
                Point p2f = new Point((int)pointsofsquare2[0], (int)pointsofsquare2[1]);
                Point p3f = new Point((int)pointsofsquare1[0], (int)pointsofsquare1[1]);

                Point[] punctef = new Point[4];
                punctef[0] = p0f;
                punctef[1] = p1f;
                punctef[2] = p2f;
                punctef[3] = p3f;

                ig.FillPolygon(new SolidBrush(Color.Tomato), punctef);
              /*  */

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
                fillFaces();
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
            cubul1.creategrafics(this);
            cubul1.draw();

            cubul2.creategrafics(this);
            cubul2.draw();

        }


        public cub cubul1 = new cub(250,250,250,50,50,50);
        public cub cubul2 = new cub(350, 350, 250, 50, 50, 50);


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1024;
           
           
        }

        public void animate()
        {
            for (int i = 0; i < 10; i++)
            {
                cubul1.worldAngle += 5;
                cubul2.worldAngle += 20;
                drawAllCubes();
            }
        }

        public void drawAllCubes()
        {
            cubul1.clear();
            cubul1.draw();
            cubul2.draw();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cubul1.worldAngle += 5 ;
            drawAllCubes();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cubul1.worldAngle -= 5;
            drawAllCubes();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cubul2.worldAngle += 20;
            drawAllCubes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cubul2.worldAngle -= 20;
            drawAllCubes();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            animate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ismousdown = true;
            preposxm = e.X;
            preposym = e.Y;

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (ismousdown == true)
            { 
                posym = e.Y;
                posxm = e.X;

                if (preposxm > posxm && thisworldAngle<360) { thisworldAngle = +cubul1.distantaintredouapuncte2dxy(posxm,posym,preposxm,preposym)/100; }
                else if (preposxm < posxm && thisworldAngle > -360) { thisworldAngle = -cubul1.distantaintredouapuncte2dxy(posxm, posym, preposxm, preposym) /100; }
                Text = thisworldAngle.ToString();
                cubul1.worldAngle += thisworldAngle;
                cubul2.worldAngle += thisworldAngle;
                drawAllCubes();

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ismousdown = false;
        }
    }
}
