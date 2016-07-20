using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class MyPolygon
    {
        public List<MyRectangle> points;
        public bool isSelected;
        public bool isComplete;
        public int index;
        public List<MyPolygon> innerPolygonList;
        public MyPolygon()
        {
            this.points = new List<MyRectangle>();
            this.isSelected = false;
            this.isComplete = false;
            innerPolygonList = new List<MyPolygon>();
        }

        public MyPolygon(List<MyRectangle> points)
        {
            this.points = points;
            this.isSelected = false;
            this.isComplete = false;
            innerPolygonList = new List<MyPolygon>();
        }

        public List<PointF> GetPoints()
        {
            List<PointF> points = new List<PointF>();
            foreach (var item in this.points)
            {
                points.Add(new PointF (item.rect.X+5,item.rect.Y+5));
            }
            return points;
        }
    }
}
