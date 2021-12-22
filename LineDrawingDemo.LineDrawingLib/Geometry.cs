using LineDrawingDemo.LineDrawingLib.Models;
using System.Drawing;

namespace LineDrawingDemo.LineDrawingLib
{
    // source: http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
    public class Geometry
    {
        public Orientation ComputeOrientation(Point pointA, Point pointB, Point pointC)
        {
            var result = (pointB.Y - pointA.Y) * (pointC.X - pointB.X) - (pointB.X - pointA.X) * (pointC.Y - pointB.Y);

            if (result > 0) { return Orientation.Clockwise; }

            return result == 0 ? Orientation.Collinear : Orientation.Counterclockwise;
        }
    }
}
