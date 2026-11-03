using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_DuyetDanhSachDonHang
{
    public class Order
    {
        public string Code { get; set; }
        public double Total { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 16: ITERATOR DUYET DON HANG ===");
            List<Order> orders = new List<Order>
            {
                new Order { Code = "HD01", Total = 150000 },
                new Order { Code = "HD02", Total = 500000 }
            };

            using (var iterator = orders.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    Console.WriteLine($"Don hang: {iterator.Current.Code} - {iterator.Current.Total:N0}d");
                }
            }
        }
    }
}
