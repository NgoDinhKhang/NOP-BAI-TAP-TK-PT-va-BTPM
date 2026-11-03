using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Decorator
{
    public interface INotifier { void Send(string msg); }
    public class EmailNotifier : INotifier { public void Send(string msg) => Console.WriteLine($"Email: {msg}"); }

    public class SMSDecorator : INotifier
    {
        private INotifier _wrapper;
        public SMSDecorator(INotifier wrapper) => _wrapper = wrapper;
        public void Send(string msg) { _wrapper.Send(msg); Console.WriteLine($"SMS: {msg}"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P09: DECORATOR PATTERN ===");
            INotifier notify = new SMSDecorator(new EmailNotifier());
            notify.Send("Chao ban!");
        }
    }
}
