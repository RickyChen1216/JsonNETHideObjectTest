using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JsonNETHideObjectTest
{
    public class MPolygon : MShape
    {
        public MPolygon() { }

        public MPolygon(Point point0, IEnumerable<Point> points)
        {
            Point0 = point0;
            Points = new List<Point>(points);
        }

        public Point Point0 { get; set; }
        public List<Point> Points { get; set; }
    }
}
