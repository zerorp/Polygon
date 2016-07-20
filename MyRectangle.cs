using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class MyRectangle
    {
        public RectangleF rect;
        public bool isSelected;

        public MyRectangle(RectangleF rect)
        {
            this.rect = rect;
            this.isSelected = false;
        }

        public MyRectangle()
        {
            this.rect = new RectangleF();
            this.isSelected = false;
        }
    }
}
