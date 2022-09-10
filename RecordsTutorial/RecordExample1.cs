using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTutorial
{
    public static class RecordExample1
    {
        public static void Main()
        {
            // Two types of records: value type records and reference type records

            PersonPositionalSyntax person1 = new("Harry", "Potter");
            PersonPositionalSyntax person2 = new("Harry", "Potter");

            var isEqual = person1.Equals(person2);
            var toStringValue = person1.ToString();


            // with statement allows nondestructive mutations
            // create a new copy of person that is based on the person1 object
            // but with the FirstName changed
            PersonPositionalSyntax person3 = person1 with { FirstName = "Arry" };
            var toStringValuePerson3 = person3.ToString();

            PersonPositionalSyntax person4 = new("Arry", person1.LastName);
            var toStringValuePerson4 = person4.ToString();

            var hashCodePerson1 = person1.GetHashCode();
            var hashCodePerson3 = person3.GetHashCode();
        }

    }

    // Two ways to define a reference based record (still uses value based equality even though it is a ref type)
    // you can options add class to a record to make it clear it is a reference type
    public record PersonPositionalSyntax(string FirstName, string LastName); // postitional syntax creates properties and constructor automatically
    
    public record class PersonRegularSyntax // this long form is equivalent to the positional synax above
    {
        public PersonRegularSyntax(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; init; } = default!;
        public string LastName { get; init; } = default!;
    }   

    // Two ways to define a value type record
    public readonly record struct PointPositionalSyntax(double X, double Y, double Z); // to create an immutable struct you must add readonly
    // these two syntax are equivalent
    public record struct PointRegularSyntax
    {
        public PointRegularSyntax(double x, double y, double z)
        {
            X = x;
            Z = z;
            Y = y;
        }

        public double X { get; init; } // change init to set to make this mutable
        public double Y { get; init; }
        public double Z { get; init; }
    }


















    // What is a record?
    // A record is a reference type that uses value based equality.
    // Records have built in features that make creating an immutable object so you dont need to write all this code we look at (show code)
    // and write a custom equals function that includes each of the fields in your class
    // records provider a very simple and easy to use syntax for creating objects
    // especially if you need immutability and value based equality
    // but even if you don't there a lots of situations where records can be used
    // isnstead of classes and structs
    // records also override toString and provide which provides a convenient way to output the values of the fields within an instance of your record
    // method for displaying data

    // Why not just use a struct?
    // A struct can not be used for inheritance
    // so if you need to create a hierarchical data structure
    // but you want value based equality then use a record

    // Good use cases for record:
    // DTO or Data Transfer Object.
    // Let's say you have an API call that retreives some data directly from the database
    // and returns it to the user in a GET request
    // You don't want to expose your database model so you need to map it
    // to another type before it is passed back to the user
    // if you don't plan on modifying this data once it has been initiazed
    // then a record is a good case for that

    // Let's say you have search functionality on your website,
    // a record is a good use case for a SearchParams record where
    // each field in the record is one of the search options

    // Lastly for data science type work where you are dealing with collections of data/
    // this is a good use case for the value based equality you would want with data science work

    // Note about EFCore: Reference equality is required for some data models.For example, [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
    // depends on reference equality to ensure that it uses only one instance of an entity type for what is conceptually one entity. For this reason,
    // records and record structs aren't appropriate for use as entity types in Entity Framework Core.

}
