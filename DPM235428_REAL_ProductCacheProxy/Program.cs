using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_ProductCacheProxy
{
    public interface IProductService { string GetProduct(int id); }

    public class RealProductService : IProductService
    {
        public string GetProduct(int id)
        {
            Console.WriteLine($"[SQL DB Query]: Truy van CSDL cho SP #{id}...");
            return $"San pham dien tu #{id}";
        }
    }

    public class ProductServiceProxy : IProductService
    {
        private readonly RealProductService _real = new RealProductService();
        private readonly Dictionary<int, string> _cache = new Dictionary<int, string>();

        public string GetProduct(int id)
        {
            if (_cache.ContainsKey(id))
            {
                Console.WriteLine($"[REDIS CACHE HIT]: Lay nhanh tu RAM cho SP #{id}");
                return _cache[id];
            }

            string data = _real.GetProduct(id);
            _cache[id] = data;
            return data;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 12: PROXY PRODUCT CACHE ===");
            IProductService service = new ProductServiceProxy();
            service.GetProduct(101);
            service.GetProduct(101);
        }
    }
}
