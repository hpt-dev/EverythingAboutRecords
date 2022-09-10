using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTutorial
{
    public static class EqualityExample2
    {
        public static void Main()
        {
            var point1 = new Point3d(1, 2, 3);
            var point2 = new Point3d(1, 2, 3);

            var equalityCheck1 = point1 == point2;
            var equalityCheck2 = point1.Equals(point2);

            // Hashcode are used in dictionaries to uniquely identify each item in constant time
            // by creating a hash table
            // If you have two instances of a struct Point(x,y,z)
            // then there hashes will be equal if x = x, y = y and z = z
            // for reference equality this will not be true
            var point1Hash = point1.GetHashCode();
            var point2Hash = point2.GetHashCode();
        }
    }

    //public class Point3d
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public int Z { get; set; }

    //    public Point3d(int x, int y, int z)
    //    {
    //        X = x;
    //        Y = y;
    //        Z = z;
    //    }
    //}

    // IEquatable interface contains a definition for type specific equals method bool Equals(T? other);
    public class Point3d : IEquatable<Point3d>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point3d(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // override the System.Object equals method that accepts an Object and point it to
        // the type specific equals below.
        public override bool Equals(object obj) => this.Equals(obj as Point3d);

        //Implement a type specific equals method
        // that checks if two Point3d are equal by value.
        public bool Equals(Point3d p)
        {
            if (p is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, p))
            {
                return true;
            }

            // Check properties that this class declares.
            if (Z == p.Z && X == p.X && Y == p.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // generate a hashcode that is made up of the individual hashcode from int x,y,z
        // this is important because we want the hashcodes of two instances to be equal
        // when x,y,z of each instance are the same
        // used in dictionaries and other hash based collections like hashmap
        public override int GetHashCode() => (X, Y, Z).GetHashCode();

        // make the == operator used value based equality
        public static bool operator ==(Point3d lhs, Point3d rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    // null == null = true.
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles the case of null on right side.
            return lhs.Equals(rhs);
        }

        // make the != operator used value based equality
        public static bool operator !=(Point3d lhs, Point3d rhs) => !(lhs == rhs);
    }
}
