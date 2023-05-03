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
    public class MCircle : MShape
    {
        public MCircle() { }

        public MCircle(Point center, double radius)
        {
            Center = center;
            RadiusX = radius;
            RadiusY = radius;
        }

        public Point Center { get; set; }
        public double RadiusX { get; set; }
        public double RadiusY { get; set; }
    }
}
