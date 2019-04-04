using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Data;

namespace DataStructures.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4};
            var result = ArrangeSet<int>.QuickSort(list);

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
