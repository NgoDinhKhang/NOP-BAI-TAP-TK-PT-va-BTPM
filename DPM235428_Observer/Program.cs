using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Observer
{
    public interface IObserver { void Update(string state); }
    public class Subject
    {
        private List<IObserver> _observers = new List<IObserver>();
        public void Attach(IObserver obs) => _observers.Add(obs);
        public void Notify(string state) { foreach (var obs in _observers) obs.Update(state); }
    }

    public class ConcreteObserver : IObserver
    {
        public void Update(string state) => Console.WriteLine($"Nhan thong bao trang thai moi: {state}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P19: OBSERVER PATTERN ===");
            Subject subject = new Subject();
            subject.Attach(new ConcreteObserver());
            subject.Notify("Da cap nhat du lieu!");
        }
    }
}
