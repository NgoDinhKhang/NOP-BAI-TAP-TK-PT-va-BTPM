using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_FlyweightProductSpec
{
    public class ProductSpecification
    {
        public string ModelName { get; set; }
        public string Specs { get; set; }
    }

    public class FlyweightFactory
    {
        private static readonly Dictionary<string, ProductSpecification> _specs = new Dictionary<string, ProductSpecification>();

        public static ProductSpecification GetSpec(string model, string details)
        {
            if (!_specs.ContainsKey(model))
            {
                _specs[model] = new ProductSpecification { ModelName = model, Specs = details };
            }
            return _specs[model];
        }
    }

    public class OrderItem
    {
        public string SerialNumber { get; set; }
        public ProductSpecification Spec { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 11: FLYWEIGHT PRODUCT SPEC ===");
            var sharedSpec = FlyweightFactory.GetSpec("iPhone 15 Pro", "A17 Pro, 256GB, Titanium");

            var item1 = new OrderItem { SerialNumber = "SN-001", Spec = sharedSpec };
            var item2 = new OrderItem { SerialNumber = "SN-002", Spec = sharedSpec };

            Console.WriteLine($"Cung dung chung RAM Spec? {object.ReferenceEquals(item1.Spec, item2.Spec)}");
        }
    }
}
