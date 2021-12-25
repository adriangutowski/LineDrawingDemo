using LineDrawingDemo.LineDrawingLib.Models;
using System;
using System.Drawing;

namespace LineDrawingDemo.LineDrawingLib
{
    // Source: http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
    public static class Geometry
    {
        /// <summary>
        /// Bottommost point as reference for comparing angles
        /// </summary>
        private static Point _bottommostPoint;

        /// <summary>
        /// Computes simple closed path for array of points (13th slide)
        /// </summary>
        public static void ComputeSimpleClosedPath(ref Point[] points)
        {
            FindBottommost(ref points, out int index);

            // Move bottommost point to first position in array
            SwapPositions(ref points[0], ref points[index]);

            // Sort points by angle (ascending) with respect to bottommost point
            _bottommostPoint = points[0];
            Array.Sort(points, CompareAngles);
        }

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
            if (abcOrientation != abdOrientation && cdaOrientation != cdbOrientation) return true;

            // Check whether four special cases are satisfied (9th slide)
            if (abcOrientation == Orientation.Collinear) return BelongsToSegment(pointA, pointB, pointC); 
            if (abdOrientation == Orientation.Collinear) return BelongsToSegment(pointA, pointB, pointD); 
            if (cdaOrientation == Orientation.Collinear) return BelongsToSegment(pointC, pointD, pointA); 
            if (cdbOrientation == Orientation.Collinear) return BelongsToSegment(pointC, pointD, pointB); 

            return false;
        }

        /// <summary>
        ///  Computes orientation of point C with respect to line segment AB (10th slide)    
        /// </summary>
        private static Orientation ComputeOrientation(Point pointA, Point pointB, Point pointC)
        {
            var result = (pointB.Y - pointA.Y) * (pointC.X - pointB.X) - (pointB.X - pointA.X) * (pointC.Y - pointB.Y);

            if (result > 0) return Orientation.Clockwise;

            return result < 0 ? Orientation.Counterclockwise : Orientation.Collinear;
        }

        /// <summary>
        /// Checks whether point C belongs to line segment AB
        /// </summary>
        private static bool BelongsToSegment(Point pointA, Point pointB, Point PointC)
        {
            var xWithinRange = PointC.X <= Math.Max(pointA.X, pointB.X) && PointC.X >= Math.Min(pointA.X, pointB.X);
            var yWithinRange = PointC.Y <= Math.Max(pointA.Y, pointB.Y) && PointC.Y >= Math.Min(pointA.Y, pointB.Y);

            return xWithinRange && yWithinRange;
        }

        /// <summary>
        /// Compares points angles using orientation
        /// </summary>
        private static int CompareAngles(Point pointA, Point pointB)
        {
            var orientation = ComputeOrientation(pointA, pointB, _bottommostPoint);

            if (orientation == Orientation.Collinear)
                return SquareDistance(_bottommostPoint, pointA) > SquareDistance(_bottommostPoint, pointB) ? 1 : -1;

            return orientation == Orientation.Clockwise ? 1 : -1;
        }

        /// <summary>
        /// Computes square of distance between points A and B
        /// </summary>
        private static double SquareDistance(Point pointA, Point pointB)
        {
            return Math.Pow(pointA.X - pointB.X, 2) + Math.Pow(pointA.Y - pointB.Y, 2);
        }

        /// <summary>
        /// Finds index of bottommost point in array
        /// </summary>
        private static void FindBottommost(ref Point[] points, out int index)
        {
            index = 0;
            var y = points[index].Y;
            for (int i = 1; i < points.Length; i++)
            {
                // Choose bottommost or leftmost point if tie
                if ((points[i].Y < y) || (y == points[i].Y && points[i].X < points[index].X))
                {
                    y = points[i].Y;
                    index = i;
                }

            }
        }

        /// <summary>
        /// Swaps positions of two points in array
        /// </summary>
        private static void SwapPositions(ref Point pointA, ref Point pointB)
        {
            Point temporaryPoint = pointA;
            pointA = pointB;
            pointB = temporaryPoint;
        }
    }
}
