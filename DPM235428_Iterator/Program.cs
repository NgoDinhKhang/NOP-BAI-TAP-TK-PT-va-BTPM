using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P16: ITERATOR PATTERN ===");
            List<string> items = new List<string> { "Item A", "Item B", "Item C" };
            using (var iterator = items.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    Console.WriteLine($"Duyet qua Iterator: {iterator.Current}");
                }
            }
        }
    }
}
