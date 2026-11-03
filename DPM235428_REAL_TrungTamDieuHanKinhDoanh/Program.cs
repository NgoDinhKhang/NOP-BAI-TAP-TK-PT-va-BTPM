using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_TrungTamDieuHanKinhDoanh
{
    public interface IMediator { void Notify(string sender, string ev); }

    public class SalesMediator : IMediator
    {
        public void Notify(string sender, string ev)
        {
            if (ev == "ORDER_CREATED")
            {
                Console.WriteLine($"[MEDIATOR]: Nhan thong bao tu {sender} -> Kich hoat Tru Kho va Tao Van Don.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 17: MEDIATOR POS CONTROL ===");
            IMediator mediator = new SalesMediator();
            mediator.Notify("Bo phan POS", "ORDER_CREATED");
        }
    }
}
