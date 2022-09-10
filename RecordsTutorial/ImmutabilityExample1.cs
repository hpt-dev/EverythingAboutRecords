using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTutorial
{
    public static class ImmutabilityExample1
    {
        public static void Main()
        {
            string immutableString = "This is a";
            // Here I have pointed immutableString to the memory location of " test"
            // I havent't modifed immutableString I've pointed it to a difference place in memory
            immutableString = " test";

            immutableString += "okkllkjkjkl"; // again here we have not modified the existing string
                // we have created a new string

            // This problem of creating lots of intermediate strings while adding a bunch of string together
            // is why we should always use StringBuilder when we are adding lots of strings together
            // e.g. when creating the body of an email from a set of data.
        }












        // Immutability means that something cannot change
        // If field in a class is immutable then it cannot be modified once initialized.
        // Immutability is a useful property in programming e.g.
        //
        // 1. Immutability makes your program helps avoid potential bugs,
        // if you know a value will not change once it has been initialized 
        // you are not going to run into situations where something unexpected happens with that value
        // which leads to an error.
        //
        // 2. Is thread-safe which helps avoid race conditions
        // This is similar to point 1 - if a property is immutable it cannot be accidentally changed my another 
        // thread when working with asynchronous code so it is safe to share that property and use it
        // with multiple threads.
        //
        // Instances of immutable types are inherently thread-safe, since no thread can modify it, the risk of a
        // thread modifying it in a way that interferes with another is remove
        //
        // 3. No need to write defensive code to make sure a value hasn't changed
        // this makes your code easier to read and understand

        // Problem with Immutability
        // If you have a instance of a class and you need to change just 1 field of the class
        // you will need to create a new instance of that class.
        // if this happens a lot your application could suffer from memory/performance problems

        // Great post on immutability: https://blog.ndepend.com/c-sharp-immutable-types-understanding-attraction/
    }
}
