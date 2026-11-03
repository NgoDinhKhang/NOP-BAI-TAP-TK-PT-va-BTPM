using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_OrderDisplayBridge
{
    public interface IOrderRenderer { void RenderUI(string info); }

    public class PosTouchRenderer : IOrderRenderer
    {
        public void RenderUI(string info) => Console.WriteLine($"[MAN HINH POS TOUCH]: {info}");
    }

    public abstract class OrderLogic
    {
        protected IOrderRenderer _renderer;
        protected OrderLogic(IOrderRenderer renderer) => _renderer = renderer;
        public abstract void Process();
    }

    public class RetailOrderLogic : OrderLogic
    {
        public RetailOrderLogic(IOrderRenderer renderer) : base(renderer) { }
        public override void Process() => _renderer.RenderUI("Hien thi giao dien ban le voi nut tinh tien nhanh.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 07: BRIDGE ORDER DISPLAY ===");
            OrderLogic order = new RetailOrderLogic(new PosTouchRenderer());
            order.Process();
        }
    }
}
