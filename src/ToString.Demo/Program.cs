using System;

namespace ToString.Demo
{
    public class Program
    {
        static void Main()
        {
            Person person = new() { FirstName = "Sam", LastName = "Van den Bossche", UserCode ="sambos", Age = 33};
            Console.WriteLine(person);
        }
    }


}
