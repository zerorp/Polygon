using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public static class Helper
    {
        public static PointF CalPolygonCenterPoint(List<PointF> list)
        {
            if (1 == list.Count)
            {
                return list[0];
            }
            else if (2 == list.Count)
            {
                return new PointF((list[0].X + list[0].X) / 2, (list[1].Y + list[1].Y) / 2);
            }
            else if (list.Count >= 3)
            {
                List<PointF> newList = new List<PointF>();
                for (int i = 1; i < list.Count - 1; ++i)
                {
                    newList.Add(CalTriCenterPoint(list[0], list[i], list[i + 1]));
                }
                return CalPolygonCenterPoint(newList);
            }
            else
            {
                throw new Exception("node list is null");
            }
        }

        private static PointF CalTriCenterPoint(PointF pt1, PointF pt2, PointF pt3)
        {
            float x = pt1.X + pt2.X + pt3.X;
            x /= 3;
            float y = pt1.Y + pt2.Y + pt3.Y;
            y /= 3;
            return new PointF(x, y);
        }

        public static RectangleF CalBoaderRect(List<PointF> list)
        {
            RectangleF rect = new RectangleF();
            rect.X = list.Min(point => point.X) - 10;
            rect.Y = list.Min(point => point.Y) - 10;

            rect.Width = list.Max(point => point.X) - rect.X + 20;
            rect.Height = list.Max(point => point.Y) - rect.Y + 20;

            return rect;
        }

        public static bool IsSelected(MyPolygon polygon, Point point)
        {
            bool isSelected = false;

            foreach (var rect in polygon.points)
            {
                if (rect.rect.Contains(point))
                    isSelected = true;
            }
            return isSelected;
        }
    }
}
