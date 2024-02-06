
namespace LineSegmentLib
{
    public class LineSegment
    {
        public int Start { get; }
        public int End { get;  }

        public LineSegment(int start, int end)
        {
            if (start > end)
            {
                throw new System.ArgumentException("Start must be less than or equal to end");
            }
            Start = start;
            End = end;
        }

        public override string ToString()
        {
            return $"{Start}...{End}";
        }

        public bool Contains(int point)
        {
            return Start <= point && point <= End;
        }

        public bool Contains(LineSegment anotherSegment)
        {
            return Contains(anotherSegment.Start) && Contains(anotherSegment.End);
        }

        public override bool Equals(object? obj)
        {
            if (obj is LineSegment segment)
            {
                return Start == segment.Start && End == segment.End;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode() ^ End.GetHashCode();
        }

        public LineSegment? Intersection(LineSegment anotherSegment)
        {
            int start = System.Math.Max(Start, anotherSegment.Start);
            int end = System.Math.Min(End, anotherSegment.End);
            if (start <= end)
            {
                return new LineSegment(start, end);
            }
            return null;
        }
    }
}
