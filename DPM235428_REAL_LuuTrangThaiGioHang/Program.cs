using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_LuuTrangThaiGioHang
{
    public class CartMemento
    {
        public string ItemsState { get; }
        public CartMemento(string state) => ItemsState = state;
    }

    public class ShoppingCart
    {
        public string Items { get; set; }
        public CartMemento SaveSnapshot() => new CartMemento(Items);
        public void Restore(CartMemento memento) => Items = memento.ItemsState;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 18: MEMENTO CART RESTORE ===");
            var cart = new ShoppingCart { Items = "1x Ao thun, 2x Quan Jeans" };
            var snapshot = cart.SaveSnapshot();

            cart.Items = "Rong (Loi mat ket noi)";
            Console.WriteLine($"Trang thai loi: {cart.Items}");

            cart.Restore(snapshot);
            Console.WriteLine($"Da khoi phuc gio hang: {cart.Items}");
        }
    }
}
