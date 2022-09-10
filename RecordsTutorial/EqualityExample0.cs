

public static class EqualityExample0
{ 
    public static void Main()
    {
        var test1 = new TestClass() { Name = "Tom", Age = 20 };
        var test2 = new TestClass() { Name = "Tom", Age = 20 };
        var isEqual1 = test1 == test2;

        int a = 1;
        int b = 1;
        var isEqual2 = a == b;

        string c = "abc";
        string d = "abc";
        var isEqual3 = c == d;
    }
}


public class TestClass
{
    public string Name { get; set; }
    public int Age { get; set; }
}
