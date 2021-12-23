using NUnit.Framework;
using System.Drawing;

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
    }
}