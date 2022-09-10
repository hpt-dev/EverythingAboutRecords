using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTutorial
{
    public static class ImmutabilityExample2
    {
        public static void Main()
        {
            var point1 = new MutablePoint2D(1, 2);

            // these class properties are mutable as we can change the values without error
            point1.X = 3;
            point1.Y = 4;

            var point2 = new ImmutablePoint2D(1, 2);

            // these class properties are immutable as we get an error if we try to change them
            //point2.X = 3;
            //point2.Y = 4;
        }
    }

    public class MutablePoint2D
    {
        public MutablePoint2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ImmutablePoint2D
    {
        public ImmutablePoint2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; init; }
        public int Y { get; init; }
    }

}
