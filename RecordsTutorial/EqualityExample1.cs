using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTutorial
{
    public static class EqualityExample1
    {

        public static void Main()
        {
            var pointClass1 = new PointClass() { X = 1, Y = 2, Z = 3 };
            var pointClass2 = new PointClass() { X = 1, Y = 2, Z = 3 };

            var pointStruct1 = new PointStruct() { X = 1, Y = 2, Z = 3 };
            var pointStruct2 = new PointStruct() { X = 1, Y = 2, Z = 3 };

            var isClassEqual1 = pointClass1.Equals(pointClass2);
       
            // if we make as pointClass1 and pointClass2 point to the same object then they will be equal
            // by reference:
            pointClass2 = pointClass1;
            var isClassEqual3 = Object.ReferenceEquals(pointClass1, pointClass2);

            // a struct inherits from System.ValueType which means
            // the two pointStruct will be equal as long as x,y,z are equal.
            var isStructEqual1 = pointStruct1.Equals(pointStruct2);

            // value based
            int a = 1;
            int b = 1;
            var isIntEqual1 = a == b;
            var isIntEqual2 = a.Equals(b);

            // reference based
            string c = "abc";
            string d = "abc";
          
            var isStringEqual1 = c == d;
            var isStringEqual2 = c.Equals(d);

            string e = String.Copy(d);

            var isStringEqual3 = e == d;
            var isStringEqual4 = e.Equals(d);

            Console.WriteLine("");
            Console.ReadLine();
        }

        public class PointClass // ref type inherits from System.Object
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }

        public struct PointStruct // value type inherits from System.ValueType
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }


        }













        // Source code for System.Object:
        // https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Object.cs,517682d5f6f4f8b4

        // Source code for System.ValueType:
        // https://source.dot.net/#System.Private.CoreLib/src/System/ValueType.cs,915ba3e46633f948

        // Reference Equality comes from System.Object inheritance
        // Two objects have reference equality if they are the same object, i.e.they both point to the same location 
        // in memory: as a result everything about them is identical as they are the same object. this is a very 
        // strict type of equality

        // Value based equality comes from System.ValueType inheritance
        // Which all values types inherit from, this class overrides the equality methods of system.object and
        // changes them to return true when the value is equal rather than the memory location with reference
        // based equality.
        // e.g. two structs are equal when all the fields inside it have the same value
        // two ints are equal if they have the same value
        // while a strinct is a reference type it has value based equality i.e. "abc" == "abc" is true even though
        // they are difference objects in memory

        //better to use ReferenceEquals when checking for equality as you
        // can override Equals() in every class so behavior is not guarunteed
        //var isClassEqual2 = Object.ReferenceEquals(pointClass1, pointClass2);
        //var isStructEqual2 = ValueType.Equals(pointStruct1, pointStruct2);
    }
}
