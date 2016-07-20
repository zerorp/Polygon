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
using System.Drawing.Design;

//namespace WindowsFormsApplication1
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private MyRectangle currentRect = new MyRectangle();
        private PointF m_LastMSPointF;
        //private bool isComplete = false;
        private List<MyPolygon> polygonList = new List<MyPolygon>();
        private int currentPolygonIndex = 0;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            //this.UpdateStyles();
            polygonList.Add(new MyPolygon());
            polygonList[currentPolygonIndex].index = currentPolygonIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (polygonList[currentPolygonIndex].points.Count > 0)
            {
                Graphics g = myPanel1.CreateGraphics();
                Pen pen = new Pen(Color.Red);
                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].points)
                {
                    PointF curPoint = new PointF(item.rect.Location.X + 5.0f, item.rect.Location.Y + 5.0f);
                    PointFList.Add(curPoint);
                }

                //DoubleBufferFillPolygon(myPanel1.CreateGraphics(), PointFList.ToArray(), pen);
                g.FillPolygon(pen.Brush, PointFList.ToArray(), FillMode.Winding);
                polygonList[currentPolygonIndex].isComplete = true;
            }
            myPanel1.Invalidate();
            PrintOutput();

        }

        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawAxes(e.Graphics);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (var polygon in polygonList)
            {
                foreach (var item in polygon.points)
                {
                    if (item != null
                        && item.rect != null
                        && polygon.isSelected)
                    {
                        //DoubleBufferDrawRectangle(e.Graphics, item.rect, Pens.Blue);
                        e.Graphics.DrawRectangle(Pens.Black, item.rect.X, item.rect.Y, item.rect.Width, item.rect.Height);
                        e.Graphics.FillRectangle(Brushes.Blue, item.rect);
                    }
                    else if (!polygon.isSelected)
                    {
                        //DoubleBufferDrawRectangle(e.Graphics, item.rect, SystemPens.ControlDarkDark);
                        e.Graphics.FillRectangle(SystemBrushes.ControlDark, item.rect);
                        e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, item.rect.X, item.rect.Y, item.rect.Width, item.rect.Height);
                    }
                    if (currentRect.isSelected)
                    {
                        //DoubleBufferDrawRectangle(e.Graphics, currentRect.rect, Pens.Blue);
                        e.Graphics.DrawRectangle(Pens.Black, item.rect.X, item.rect.Y, item.rect.Width, item.rect.Height);
                        e.Graphics.FillRectangle(Brushes.Blue, currentRect.rect);
                    }
                    else
                    {
                        //DoubleBufferDrawRectangle(e.Graphics, currentRect.rect, SystemPens.ControlDarkDark);
                        e.Graphics.FillRectangle(SystemBrushes.ControlDark, currentRect.rect);
                        e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, item.rect.X, item.rect.Y, item.rect.Width, item.rect.Height);
                    }

                    //richTextBox1.AppendText("current1=" + current1 + "\r\n");
                }
                if (polygon.points.Count > 0/* && isComplete*/)
                {
                    Pen pen;
                    if (polygon.isComplete)
                    {
                        pen = new Pen(Color.Green);
                    }
                    else
                    {
                        pen = new Pen(Color.Red);
                    }
                    List<PointF> PointFList = new List<PointF>();
                    foreach (var item in polygon.points)
                    {
                        PointF curPointF = new PointF(item.rect.Location.X + 5, item.rect.Location.Y + 5);
                        PointFList.Add(curPointF);
                    }

                    //DoubleBufferFillPolygon(e.Graphics, PointFList.ToArray(), pen);
                    e.Graphics.FillPolygon(pen.Brush, PointFList.ToArray(), FillMode.Winding);
                    //isComplete = true;
                }
            }

            PrintOutput();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            polygonList = new List<MyPolygon>();
            polygonList.Add(new MyPolygon());
            currentPolygonIndex = 0;
            currentRect = new MyRectangle();
            myPanel1.Invalidate();
        }


        private void DoubleBufferDrawRectangle(Graphics displayGraphics, RectangleF rect, Pen pen, bool isfFill = true)
        {
            Image image = new Bitmap(myPanel1.Width, myPanel1.Height);
            Graphics g = Graphics.FromImage(image);

            if (isfFill)
            {
                g.FillRectangle(pen.Brush, rect);
            }
            else
            {
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Y);
            }

            displayGraphics.DrawImage(image, myPanel1.ClientRectangle);
            image.Dispose();
        }

        private void DoubleBufferFillPolygon(Graphics displayGraphics, PointF[] PointFs, Pen pen)
        {
            Image image = new Bitmap(myPanel1.Width, myPanel1.Height);
            Graphics g = Graphics.FromImage(image);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.FillPolygon(pen.Brush, PointFs, FillMode.Winding);
            displayGraphics.DrawImage(image, myPanel1.ClientRectangle);
            image.Dispose();

        }

        private void DrawAxes(Graphics displayGraphics)
        {
            displayGraphics.DrawLine(Pens.Black, new PointF(myPanel1.ClientSize.Width / 2, 0), new PointF(myPanel1.ClientSize.Width / 2, myPanel1.ClientSize.Height));
            displayGraphics.DrawLine(Pens.Black, new PointF(0, myPanel1.ClientSize.Height / 2), new PointF(myPanel1.ClientSize.Width, myPanel1.ClientSize.Height / 2));

        }

        private void myPanel1_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                contextMenuStrip1.Show(myPanel1.PointToScreen(e.Location));
                return;
            }
            if (!polygonList[currentPolygonIndex].isComplete)
            {
                this.m_LastMSPointF = e.Location;

                Rectangle rect = new Rectangle(e.X - 5, e.Y - 5, 10, 10);
                polygonList[currentPolygonIndex].points.Add(new MyRectangle(rect));
                //polygonList[currentPolygonIndex].points.Add(new MyRectangle(rect));
                PrintOutput();
                Pen pen = new Pen(Color.Red);
                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].points)
                {
                    PointF curPointF = new PointF(item.rect.Location.X + 5, item.rect.Location.Y + 5);
                    PointFList.Add(curPointF);
                }
                //DoubleBufferFillPolygon(myPanel1.CreateGraphics(), PointFList.ToArray(), pen);
                Graphics g = myPanel1.CreateGraphics();
                g.FillPolygon(pen.Brush, PointFList.ToArray(), FillMode.Winding);
            }
            else
            {

                foreach (var polygon in polygonList)
                {
                    //List<PointF> PointFList = new List<PointF>();
                    //foreach (var item in polygon.points)
                    //{
                    //    PointF curPointF = new PointF(item.rect.Location.X + 5, item.rect.Location.Y + 5);
                    //    PointFList.Add(curPointF);
                    //}

                    polygon.isSelected = Helper.IsSelected(polygon, e.Location);

                    if (polygon.isSelected)
                    {
                        currentPolygonIndex = polygon.index;
                    }
                }
            }
            myPanel1.Invalidate();

            PrintOutput();

        }

        private void PrintOutput()
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText("currentSelectIndex:" + currentPolygonIndex + "\r\n");
            foreach (var polygon in polygonList)
            {
                richTextBox1.AppendText("polygon: " + polygon.index + "\r\n");
                foreach (var item in polygon.points)
                {
                    richTextBox1.AppendText(item.rect.Location + "\r\n");
                }
                richTextBox1.AppendText("isComplete: " + polygon.isComplete + "\r\n");
            }

        }

        private void myPanel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                currentRect.isSelected = false;
                return;
            }
            if (polygonList[currentPolygonIndex].isComplete)
            {
                Graphics g = myPanel1.CreateGraphics();

                if (currentRect.isSelected || currentRect.rect.Contains(e.X, e.Y))
                {
                    currentRect.rect.Offset(e.Location.X - this.m_LastMSPointF.X, e.Location.Y - this.m_LastMSPointF.Y);

                    myPanel1.Invalidate();
                }
                else
                {
                    foreach (var item in polygonList[currentPolygonIndex].points)
                    {
                        if (item.rect.Contains(e.X, e.Y))
                        {

                            currentRect = item;
                            currentRect.isSelected = true;
                            break;
                        }
                    }
                }
            }
            this.m_LastMSPointF = e.Location;
        }

        private void myPanel1_MouseUp_1(object sender, MouseEventArgs e)
        {
            currentRect.isSelected = false;
            currentRect = new MyRectangle(new Rectangle());
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                float factor = float.Parse(toolStripTextBox_ZoomValue.Text);
                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].points)
                {
                    PointF curPointF = new PointF(item.rect.Location.X, item.rect.Location.Y);
                    PointFList.Add(curPointF);
                }


                Matrix matrix = new Matrix();

                PointF center = Helper.CalPolygonCenterPoint(PointFList);

                matrix.Translate(-center.X, -center.Y);

                matrix.Scale(factor, factor, MatrixOrder.Append);

                matrix.Translate(center.X / factor, center.Y / factor);

                PointF[] points = PointFList.ToArray();

                matrix.TransformPoints(points);

                for (int i = 0; i < points.Length; i++)
                {
                    polygonList[currentPolygonIndex].points[i].rect.Location = points[i];
                }
                myPanel1.Invalidate();
            }
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].points)
                {
                    PointF curPointF = new PointF(item.rect.Location.X, item.rect.Location.Y);
                    PointFList.Add(curPointF);
                }


                Matrix matrix = new Matrix();

                PointF center = Helper.CalPolygonCenterPoint(PointFList);

                matrix.RotateAt((float)(float.Parse(toolStripTextBox_RotateValue.Text)), center);
                PointF[] points = PointFList.ToArray();
                matrix.TransformPoints(points);
                for (int i = 0; i < points.Length; i++)
                {
                    polygonList[currentPolygonIndex].points[i].rect.Location = points[i];
                }
                myPanel1.Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            polygonList.Add(new MyPolygon());
            currentPolygonIndex = polygonList.Count - 1;
            polygonList[currentPolygonIndex].index = currentPolygonIndex;
        }

        private void toolStripMenuItem_New_Click(object sender, EventArgs e)
        {
            polygonList.Add(new MyPolygon());
            currentPolygonIndex = polygonList.Count - 1;
            polygonList[currentPolygonIndex].index = currentPolygonIndex;
        }

        private void toolStripMenuItem_Complete_Click(object sender, EventArgs e)
        {
            if (polygonList[currentPolygonIndex].points.Count > 0)
            {
                Graphics g = myPanel1.CreateGraphics();
                Pen pen = new Pen(Color.Red);
                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].points)
                {
                    PointF curPoint = new PointF(item.rect.Location.X + 5.0f, item.rect.Location.Y + 5.0f);
                    PointFList.Add(curPoint);
                }

                //DoubleBufferFillPolygon(myPanel1.CreateGraphics(), PointFList.ToArray(), pen);
                g.FillPolygon(pen.Brush, PointFList.ToArray(), FillMode.Winding);
                polygonList[currentPolygonIndex].isComplete = true;
            }
            myPanel1.Invalidate();
            PrintOutput();
        }

        private void toolStripMenuItem_Clear_Click(object sender, EventArgs e)
        {
            polygonList = new List<MyPolygon>();
            polygonList.Add(new MyPolygon());
            currentPolygonIndex = 0;
            currentRect = new MyRectangle();
            myPanel1.Invalidate();
        }
    }
}