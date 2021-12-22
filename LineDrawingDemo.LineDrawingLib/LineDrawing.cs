using LineDrawingDemo.LineDrawingLib.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace LineDrawingDemo.LineDrawingLib
{
    public static class LineDrawing
    {
        private static readonly List<Line> _lines = new List<Line>();

        public static List<Line> GetLines() => _lines;

        public static void AddNewLine() => _lines.Add(new Line());

        public static void AddNewPoint(Point point) => _lines.Last().Points.Add(point);
    }
}
