using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_GhtkShippingAdapter
{
    public interface IShippingService
    {
        string CreateDelivery(string address, double weightKg);
    }

    public class GhtkSdkApi
    {
        public string SendOrderRequest(string addr, int weightGram) => $"[GHTK OK] Gui don hang {weightGram}g den {addr}";
    }

    public class GhtkAdapter : IShippingService
    {
        private readonly GhtkSdkApi _ghtkApi = new GhtkSdkApi();

        public string CreateDelivery(string address, double weightKg)
        {
            int weightGram = (int)(weightKg * 1000);
            return _ghtkApi.SendOrderRequest(address, weightGram);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 06: ADAPTER SHIPPING ===");
            IShippingService shipping = new GhtkAdapter();
            Console.WriteLine(shipping.CreateDelivery("123 Le Loi, Quan 1, TP.HCM", 2.5));
        }
    }
}
