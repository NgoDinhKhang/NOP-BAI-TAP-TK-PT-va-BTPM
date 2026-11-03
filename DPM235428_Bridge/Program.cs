using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Bridge
{
    public interface IDevice { void Enable(); }
    public class Tv : IDevice { public void Enable() => Console.WriteLine("Bat Tivi"); }

    public class Remote
    {
        protected IDevice _device;
        public Remote(IDevice device) => _device = device;
        public void TogglePower() => _device.Enable();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P07: BRIDGE PATTERN ===");
            Remote remote = new Remote(new Tv());
            remote.TogglePower();
        }
    }
}
