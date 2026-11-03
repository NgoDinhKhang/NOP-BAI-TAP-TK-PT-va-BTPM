using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Prototype
{
    public class Shape : ICloneable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public object Clone() => this.MemberwiseClone();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P05: PROTOTYPE PATTERN ===");
            Shape s1 = new Shape { Width = 10, Height = 20 };
            Shape s2 = (Shape)s1.Clone();
            Console.WriteLine($"Shape 2 Clone: Width={s2.Width}, Height={s2.Height}");
        }
    }
}
