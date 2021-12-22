using System;
using System.Collections.Generic;
using System.Drawing;

namespace LineDrawingDemo.LineDrawingLib.Models
{
    public class Line
    {
        public Line()
        {
            Points = new List<Point>();
            Color = GetRandomColor();
        }

        public List<Point> Points { get; private set; }
        public Color Color { get; private set; }

        private static Color GetRandomColor()
        {
            var random = new Random();

            return Color.FromArgb(random.Next(byte.MaxValue), random.Next(byte.MaxValue), random.Next(byte.MaxValue));
        }
    }
}
