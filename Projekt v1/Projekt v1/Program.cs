using System;
using System.Collections.Generic;

namespace multidimensional_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<List<string>> Person = new List<List<string>>();
            for (int i = 0; i < 3; i++)
            {
                List<string> Data = new List<string>();
                Data.Add("Person ");
                Data.Add("Description ");
                Person.Add(Data);
            }
            foreach (var list in Person)
            {
                foreach (var element in list)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }
        }
    }
}
