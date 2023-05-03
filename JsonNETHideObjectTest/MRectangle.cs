using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JsonNETHideObjectTest
{
    public class MRectangle : MShape
    {
        public MRectangle()
        {
        }

        public MRectangle(Point p0, Point p1)
        {
            P0 = p0;
            P1 = p1;
        }

        public Point P0 { get; set; }
        public Point P1 { get; set; }
    }
}
