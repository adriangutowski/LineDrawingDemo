using LineDrawingDemo.LineDrawingLib.Models;
using System;
using System.Drawing;

namespace LineDrawingDemo.LineDrawingLib
{
    // Source: http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
    public static class Geometry
    {
        /// <summary>
        /// Checks whether line segment AB intersects with line segment CD
        /// </summary>
        public static bool SegmentsIntersect(Point pointA, Point pointB, Point pointC, Point pointD)
        {
            // Compute all possible orientations
            var abcOrientation = ComputeOrientation(pointA, pointB, pointC);
            var abdOrientation = ComputeOrientation(pointA, pointB, pointD);
            var cdaOrientation = ComputeOrientation(pointC, pointD, pointA);
            var cdbOrientation = ComputeOrientation(pointC, pointD, pointB);

            // Check whether general case is satisfied (6th slide)
            if (abcOrientation != abdOrientation && cdaOrientation != cdbOrientation) { return true; }

            // Check whether four special cases are satisfied (9th slide)
            if (abcOrientation == Orientation.Collinear) { return BelongsToSegment(pointA, pointB, pointC); }
            if (abdOrientation == Orientation.Collinear) { return BelongsToSegment(pointA, pointB, pointD); }
            if (cdaOrientation == Orientation.Collinear) { return BelongsToSegment(pointC, pointD, pointA); }
            if (cdbOrientation == Orientation.Collinear) { return BelongsToSegment(pointC, pointD, pointB); }

            return false;
        }

        /// <summary>
        ///  Computes orientation of point C with respect to line segment AB (10th slide)    
        /// </summary>
        private static Orientation ComputeOrientation(Point pointA, Point pointB, Point pointC)
        {
            var result = (pointB.Y - pointA.Y) * (pointC.X - pointB.X) - (pointB.X - pointA.X) * (pointC.Y - pointB.Y);

            if (result > 0) { return Orientation.Clockwise; }

            return result < 0 ? Orientation.Counterclockwise : Orientation.Collinear;
        }

        /// <summary>
        /// Checks whether point C belongs to line segment AB for special cases (9th slide)
        /// </summary>
        private static bool BelongsToSegment(Point pointA, Point pointB, Point PointC)
        {
            var xWithinRange = PointC.X <= Math.Max(pointA.X, pointB.X) && PointC.X >= Math.Min(pointA.X, pointB.X);
            var yWithinRange = PointC.Y <= Math.Max(pointA.Y, pointB.Y) && PointC.Y >= Math.Min(pointA.Y, pointB.Y);
         
            return xWithinRange && yWithinRange;
        }
    }
}
