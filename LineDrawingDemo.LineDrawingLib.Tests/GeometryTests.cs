using NUnit.Framework;
using System.Drawing;
using System.Linq;

namespace LineDrawingDemo.LineDrawingLib.Tests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void SegmentsIntersect_IntersectingSegments_ReturnTrue()
        {
            // Arrange
            var pointA = new Point(1, 2);
            var pointB = new Point(3, 2);
            var pointC = new Point(2, 1);
            var pointD = new Point(2, 3);

            // Act
            var segmentsIntersect = Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD);

            // Assert
            Assert.IsTrue(segmentsIntersect);
        }

        [Test]
        public void SegmentsIntersect_NotIntersectingSegments_ReturnFalse()
        {
            // Arrange
            var pointA = new Point(1, 1);
            var pointB = new Point(1, 2);
            var pointC = new Point(2, 1);
            var pointD = new Point(2, 2);

            // Act
            var segmentsIntersect = Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD);

            // Assert
            Assert.IsFalse(segmentsIntersect);
        }

        [Test]
        public void SegmentsIntersect_SpecialCase_ReturnFalse()
        {
            // Arrange
            var pointA = new Point(1, 1);
            var pointB = new Point(2, 1);
            var pointC = new Point(4, 1);
            var pointD = new Point(5, 1);

            // Act
            var segmentsIntersect = Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD);

            // Assert
            Assert.IsFalse(segmentsIntersect);
        }

        [Test]
        public void ComputeSimpleClosedPath_UnorderedPoints_ReturnOrderedPoints()
        {
            // Arrange
            var points = new Point[]
            {
                new Point(1, 4),
                new Point(2, 2),
                new Point(3, 3),
                new Point(5, 5),
                new Point(1, 1),
                new Point(2, 3),
                new Point(4, 2),
                new Point(4, 4)
            };
            var orderedPoints = new Point[]
            {
                new Point(1, 1),
                new Point(4, 2),
                new Point(2, 2),
                new Point(3, 3),
                new Point(4, 4),
                new Point(5, 5),
                new Point(2, 3),
                new Point(1, 4)
            };

            // Act
            Geometry.ComputeSimpleClosedPath(ref points);

            // Assert
            Assert.IsTrue(points.SequenceEqual(orderedPoints));
        }
    }
}