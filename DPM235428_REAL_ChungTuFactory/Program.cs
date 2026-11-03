using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_ChungTuFactory
{
    public interface IReceiptDocument { void PrintReceipt(); }
    public interface IDeliveryNote { void PrintLabel(); }

    public class ThermalReceipt : IReceiptDocument
    {
        public void PrintReceipt() => Console.WriteLine("In bien lai nhiet K80 tai quay POS.");
    }

    public class ShippingLabel : IDeliveryNote
    {
        public void PrintLabel() => Console.WriteLine("In phieu giao hang ma vach shipper.");
    }

    public interface IDocumentFactory
    {
        IReceiptDocument CreateReceipt();
        IDeliveryNote CreateDeliveryNote();
    }

    public class OnlineDocumentFactory : IDocumentFactory
    {
        public IReceiptDocument CreateReceipt() => new ThermalReceipt();
        public IDeliveryNote CreateDeliveryNote() => new ShippingLabel();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 03: ABSTRACT FACTORY CHUNG TU ===");
            IDocumentFactory factory = new OnlineDocumentFactory();
            factory.CreateReceipt().PrintReceipt();
            factory.CreateDeliveryNote().PrintLabel();
        }
    }
}
