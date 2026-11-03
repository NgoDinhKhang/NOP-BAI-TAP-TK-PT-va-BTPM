using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Builder
{
    public class House
    {
        public string Roof { get; set; }
        public int Doors { get; set; }
        public bool HasPool { get; set; }
    }

    public class HouseBuilder
    {
        private House _house = new House();
        public HouseBuilder BuildRoof(string roof) { _house.Roof = roof; return this; }
        public HouseBuilder BuildDoors(int doors) { _house.Doors = doors; return this; }
        public HouseBuilder AddPool() { _house.HasPool = true; return this; }
        public House Build() => _house;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P04: BUILDER PATTERN ===");
            var house = new HouseBuilder().BuildRoof("Mai thai").BuildDoors(4).AddPool().Build();
            Console.WriteLine($"Nha mai: {house.Roof}, So cua: {house.Doors}, Ho bieu: {house.HasPool}");
        }
    }
}
