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

        public static void AddToLastLine(Point point)
        {
            var lastLine = _lines.Last();
            lastLine.Points.Add(point);
            RemoveIfIntersecting(lastLine);
        }
        
        private static void RemoveIfIntersecting(Line lineToRemove)
        {
            if (lineToRemove.Points.Count <= 1) { return; }

            // Find last line segment coordinates
            var pointC = lineToRemove.Points[^2];
            var pointD = lineToRemove.Points[^1];

            for (int i = 0; i < _lines.Count - 1; i++)
            {
                var line = _lines[i];

                for (int j = 1; j < line.Points.Count; j++)
                {
                    // Find current line segment coordinates
                    var pointA = line.Points[j - 1];
                    var pointB = line.Points[j];

                    if (Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD))
                    {
                        _lines.Remove(lineToRemove);
                        break;
                    }
                }
            }
        }
    }
}
