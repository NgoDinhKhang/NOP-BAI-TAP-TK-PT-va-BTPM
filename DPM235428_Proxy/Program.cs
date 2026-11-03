using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Proxy
{
    public interface ISubject { void Request(); }
    public class RealSubject : ISubject { public void Request() => Console.WriteLine("Thuc hien Yeu cau Thuc te."); }

    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        public void Request()
        {
            _realSubject ??= new RealSubject();
            Console.WriteLine("[Proxy] Kiem tra quyen truoc khi goi...");
            _realSubject.Request();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P12: PROXY PATTERN ===");
            ISubject proxy = new Proxy();
            proxy.Request();
        }
    }
}
