using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Flyweight
{
    public class Flyweight
    {
        public string SharedState { get; set; }
        public Flyweight(string state) => SharedState = state;
    }

    public class FlyweightFactory
    {
        private Dictionary<string, Flyweight> _flyweights = new Dictionary<string, Flyweight>();
        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key)) _flyweights[key] = new Flyweight(key);
            return _flyweights[key];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P11: FLYWEIGHT PATTERN ===");
            var factory = new FlyweightFactory();
            var f1 = factory.GetFlyweight("A");
            var f2 = factory.GetFlyweight("A");
            Console.WriteLine($"Cung Flyweight RAM: {object.ReferenceEquals(f1, f2)}");
        }
    }
}
