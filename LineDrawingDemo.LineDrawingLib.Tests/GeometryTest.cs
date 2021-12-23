using NUnit.Framework;
using System.Drawing;

namespace LineDrawingDemo.LineDrawingLib.Tests
{
    [TestFixture]
    public class GeometryTest
    {
        [Test]
        public void SegmentsIntersect_IntersectingSegments_ReturnTrue()
        {
            // Arrange
            var pointA = new Point(10, 20);
            var pointB = new Point(30, 20);
            var pointC = new Point(20, 10);
            var pointD = new Point(20, 30);

            // Act
            var segmentsIntersect = Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD);

            // Assert
            Assert.IsTrue(segmentsIntersect);
        }

        [Test]
        public void SegmentsIntersect_NotIntersectingSegments_ReturnFalse()
        {
            // Arrange
            var pointA = new Point(10, 10);
            var pointB = new Point(10, 20);
            var pointC = new Point(20, 10);
            var pointD = new Point(20, 20);

            // Act
            var segmentsIntersect = Geometry.SegmentsIntersect(pointA, pointB, pointC, pointD);

            // Assert
            Assert.IsFalse(segmentsIntersect);
        }
    }
}