using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace WindowsFormsApplication1
{
    public partial class PolygonPanel : UserControl
    {
        private MyRectangle currentRect = new MyRectangle();
        private MyPolygon selectedPloygon = new MyPolygon();
        private PointF m_LastMSPointF;
        private List<MyPolygon> polygonList = new List<MyPolygon>();
        private List<MyPolygon> outputPolygonList = new List<MyPolygon>();
        private int currentPolygonIndex = 0;
        private int currentOutputPloygonIndex = 0;
        private bool isCut = false;

        public PolygonPanel()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            //this.UpdateStyles();
            polygonList.Add(new MyPolygon());
            polygonList[currentPolygonIndex].index = currentPolygonIndex;

        }

        private void myPanel1_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            //DrawAxes(e.Graphics);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.DrawImage(Resource1.Image1, new Rectangle(new Point(), myPanel1.ClientSize));
            foreach (var polygon in polygonList)
            {
                PaintPoints(e, polygon);
                PaintPolygon(e, polygon);
                foreach (var innerPolygon in polygon.innerPolygonList)
                {
                    PaintPoints(e, innerPolygon);
                    PaintPolygon(e, innerPolygon);
                }
            }

            PrintOutput();

        }

        private static void PaintPolygon(PaintEventArgs e, MyPolygon polygon)
        {
            if (polygon.points.Count > 0/* && isComplete*/)
            {
                Pen pen;
                if (polygon.isComplete)
                {
                    pen = new Pen(Color.FromArgb(150, Color.Green));
                }
                else
                {
                    pen = new Pen(Color.FromArgb(150, Color.Red));
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

        private void PaintPoints(PaintEventArgs e, MyPolygon polygon)
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
        }

        //private void DrawAxes(Graphics displayGraphics)
        //{
        //    displayGraphics.DrawLine(Pens.Black, new PointF(myPanel1.ClientSize.Width / 2, 0), new PointF(myPanel1.ClientSize.Width / 2, myPanel1.ClientSize.Height));
        //    displayGraphics.DrawLine(Pens.Black, new PointF(0, myPanel1.ClientSize.Height / 2), new PointF(myPanel1.ClientSize.Width, myPanel1.ClientSize.Height / 2));

        //}

        private void PrintOutput()
        {
            richTextBox1.Text = "";
            richTextBox1.AppendText("Select Index:" + currentPolygonIndex + "\r\n");
            richTextBox1.AppendText("--------------------\r\n");
            richTextBox1.AppendText("Select Points:\r\n");
            string selectedPoints = GetSelectedPoints();
            richTextBox1.AppendText(selectedPoints);

            richTextBox1.AppendText("--------------------\r\n");
            richTextBox1.AppendText("All Points:\r\n");
            string allPoints = GetAllPoints();
            richTextBox1.AppendText(allPoints);

        }

        private string GetSelectedPoints()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in selectedPloygon.GetPoints())
            {
                sb.AppendLine(item.ToString());
                //richTextBox1.AppendText(item.rect.Location + "\r\n");
            }
            sb.AppendLine();
            //richTextBox1.AppendText("isComplete: " + polygon.isComplete + "\r\n");

            return sb.ToString();
        }
        private string GetAllPoints()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var polygon in polygonList)
            {
                //richTextBox1.AppendText("polygon: " + polygon.index + "\r\n");
                foreach (var item in polygon.GetPoints())
                {
                    sb.AppendLine(item.ToString());
                    //richTextBox1.AppendText(item.rect.Location + "\r\n");
                }
                foreach (var innerPolygonList in polygon.innerPolygonList)
                {
                    foreach (var innerPoints in innerPolygonList.GetPoints())
                    {
                        sb.AppendLine("----" + innerPoints.ToString());

                    }
                    sb.AppendLine();

                }
                sb.AppendLine();
                //richTextBox1.AppendText("isComplete: " + polygon.isComplete + "\r\n");
            }
            return sb.ToString();
        }

        private void myPanel1_MouseDown_1(object sender, MouseEventArgs e)
        {

            if (e.Button != MouseButtons.Left)
            {
                contextMenuStrip1.Show(myPanel1.PointToScreen(e.Location));
                return;
            }
            else
            {
                selectedPloygon.isSelected = false;
            }
            if (!polygonList[currentPolygonIndex].isComplete)
            {
                this.m_LastMSPointF = (PointF)e.Location;

                RectangleF rect = new RectangleF(e.X - 5f, e.Y - 5f, 10f, 10f);
                polygonList[currentPolygonIndex].points.Add(new MyRectangle(rect));
                selectedPloygon = polygonList[currentPolygonIndex];
                //polygonList[currentPolygonIndex].points.Add(new MyRectangle(rect));
                PrintOutput();
                Pen pen = new Pen(Color.FromArgb(150, Color.Red));

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
            if (isCut && polygonList[currentPolygonIndex].innerPolygonList.Count > 0)
            {
                this.m_LastMSPointF = (PointF)e.Location;

                RectangleF rect = new RectangleF(e.X - 5f, e.Y - 5f, 10f, 10f);
                polygonList[currentPolygonIndex].innerPolygonList.Last().points.Add(new MyRectangle(rect));
                selectedPloygon = polygonList[currentPolygonIndex].innerPolygonList.Last();
                //polygonList[currentPolygonIndex].points.Add(new MyRectangle(rect));
                PrintOutput();
                Pen pen = new Pen(Color.FromArgb(150, Color.Red));

                List<PointF> PointFList = new List<PointF>();
                foreach (var item in polygonList[currentPolygonIndex].innerPolygonList.Last().points)
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
                    polygon.isSelected = Helper.IsSelected(polygon, e.Location);

                    if (polygon.isSelected)
                    {
                        currentPolygonIndex = polygon.index;
                        selectedPloygon = polygon;
                        break;
                    }
                    foreach (var innerPloygon in polygon.innerPolygonList)
                    {
                        innerPloygon.isSelected = Helper.IsSelected(innerPloygon, e.Location);
                        if (innerPloygon.isSelected)
                        {
                            currentPolygonIndex = polygon.index;
                            selectedPloygon = innerPloygon;
                            break;
                        }
                    }
                }
            }
            myPanel1.Invalidate();

            PrintOutput();

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
                            selectedPloygon = polygonList[currentPolygonIndex];
                            break;
                        }

                        foreach (var innerPloygonList in polygonList[currentPolygonIndex].innerPolygonList)
                        {
                            foreach (var points in innerPloygonList.points)
                            {
                                if (points.rect.Contains(e.X, e.Y))
                                {
                                    currentRect = points;
                                    currentRect.isSelected = true;
                                    selectedPloygon = innerPloygonList;
                                    break;
                                }
                            }
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

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ZoomPloygon();
                myPanel1.Invalidate();
            }
        }

        private void ZoomPloygon()
        {

            float factor = float.Parse(toolStripTextBox_ZoomValue.Text);
            List<PointF> PointFList = new List<PointF>();
            foreach (var item in selectedPloygon.points)
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
                selectedPloygon.points[i].rect.Location = points[i];
            }

        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RotatePloygon();
                myPanel1.Invalidate();
            }
        }

        private void RotatePloygon()
        {
            List<PointF> PointFList = new List<PointF>();
            foreach (var item in selectedPloygon.points)
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
                selectedPloygon.points[i].rect.Location = points[i];
            }
        }

        private void toolStripMenuItem_New_Click(object sender, EventArgs e)
        {
            if (!polygonList[currentPolygonIndex].isComplete)
            {
                MessageBox.Show("Please complete current ploygon.");
                return;
            }
            if (isCut)
            {
                MessageBox.Show("Please complete current cut.");
                return;
            }
            polygonList.Add(new MyPolygon());
            currentPolygonIndex = polygonList.Count - 1;
            polygonList[currentPolygonIndex].index = currentPolygonIndex;
            currentOutputPloygonIndex = outputPolygonList.Count - 1;
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

        private void toolStripMenuItem_Cut_Click(object sender, EventArgs e)
        {
            if (!polygonList[currentPolygonIndex].isComplete)
            {
                MessageBox.Show("Please complete current ploygon.");
                return;
            }
            if (polygonList[currentPolygonIndex].innerPolygonList.Count > 0 &&
                !polygonList[currentPolygonIndex].innerPolygonList.Last().isComplete)
            {
                MessageBox.Show("Please complete current cut.");
                return;
            }
            isCut = true;
            polygonList[currentPolygonIndex].innerPolygonList.Add(new MyPolygon());
        }

        private void toolStripMenuItem_CutCompete_Click(object sender, EventArgs e)
        {
            if (isCut)
            {
                isCut = false;
                polygonList[currentPolygonIndex].innerPolygonList.Last().isComplete = true;
                myPanel1.Invalidate();
            }
        }
    }
}
