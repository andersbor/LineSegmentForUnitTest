using LineSegmentLib;

namespace LineSegmentLibTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly LineSegment segment2_7 = new LineSegment(2, 7);
        private readonly LineSegment segment2_2 = new LineSegment(2, 2);
        private readonly LineSegment segment3_8 = new LineSegment(3, 8);
        private readonly LineSegment segment4_6 = new LineSegment(4, 6);

        [TestMethod]
        public void ConstructorTest()
        {       
            Assert.AreEqual(2, segment2_7.Start);
            Assert.AreEqual(7, segment2_7.End);
            Assert.ThrowsException<ArgumentException>(() => new LineSegment(7, 6));
        }

        [TestMethod]
        public void ToStringTest()
        {
            Assert.AreEqual("2...7", segment2_7.ToString());
            Assert.AreEqual("2...2", segment2_2.ToString());
        }

        [TestMethod]
        public void ContainsPointTest()
        {
            Assert.IsTrue(segment2_7.Contains(2));
            Assert.IsFalse(segment2_7.Contains(1));
            Assert.IsTrue(segment2_7.Contains(7));
            Assert.IsFalse(segment2_7.Contains(8));
        }

        [TestMethod]
        public void ContainsSegmentTest()
        {
            Assert.IsTrue(segment2_7.Contains(segment2_2));
            Assert.IsFalse(segment2_2.Contains(segment2_7));
            Assert.IsFalse(segment2_7.Contains(segment3_8));
            Assert.IsFalse(segment2_7.Contains(segment3_8));
            Assert.IsTrue(segment2_7.Contains(segment4_6));
            Assert.IsTrue(segment4_6.Contains(segment4_6));
            Assert.IsTrue(segment2_2.Contains(segment2_2));
        }

        [TestMethod]
        public void EqualsTest()
        {
            Assert.AreEqual(segment2_7, new LineSegment(2, 7));
            Assert.AreNotEqual(segment2_7, segment2_2);
            Assert.AreNotEqual(segment2_7, segment3_8);
            bool result = segment2_7.Equals(null);
            Assert.IsFalse(result);
            result = segment2_7.Equals("hello");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            LineSegment segment2_7Copy = new LineSegment(2, 7);
            Assert.AreEqual(segment2_7.GetHashCode(), segment2_7Copy.GetHashCode());
        }

        [TestMethod]
        public void IntersectionTest()
        {
            LineSegment? result = segment2_7.Intersection(segment3_8);
            Assert.AreEqual(new LineSegment(3, 7), result);
            result = segment2_7.Intersection(segment4_6);
            Assert.AreEqual(new LineSegment(4, 6), result);
            result = segment2_7.Intersection(segment2_2);
            Assert.AreEqual(new LineSegment(2, 2), result);
            result = segment2_7.Intersection(new LineSegment(8, 9));
            Assert.IsNull(result);
        }
    }
}