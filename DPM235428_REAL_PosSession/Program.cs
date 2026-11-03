using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_PosSession
{
    public sealed class PosSessionManager
    {
        private static PosSessionManager _instance;
        private static readonly object _lock = new object();
        private int _invoiceCounter = 1000;

        private PosSessionManager() { }

        public static PosSessionManager Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new PosSessionManager();
                }
            }
        }

        public string NextInvoiceNo()
        {
            _invoiceCounter++;
            return $"HD-{_invoiceCounter}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 01: SINGLETON POS SESSION ===");
            var s1 = PosSessionManager.Instance;
            var s2 = PosSessionManager.Instance;

            Console.WriteLine($"Hoa don 1: {s1.NextInvoiceNo()}");
            Console.WriteLine($"Hoa don 2: {s2.NextInvoiceNo()}");
            Console.WriteLine($"Cung Instance? {object.ReferenceEquals(s1, s2)}");
        }
    }
}
