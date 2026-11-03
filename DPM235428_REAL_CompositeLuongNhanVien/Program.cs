using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_CompositeLuongNhanVien
{
    public interface ISalaryComponent
    {
        string Name { get; }
        double CalculateSalary();
        void Display(int indent);
    }

    public class Employee : ISalaryComponent
    {
        public string Name { get; }
        public string Position { get; }
        public double BaseSalary { get; }

        public Employee(string name, string position, double baseSalary)
        {
            Name = name; Position = position; BaseSalary = baseSalary;
        }

        public double CalculateSalary() => BaseSalary;

        public void Display(int indent)
        {
            Console.WriteLine($"{new string(' ', indent * 2)}|- [NV] {Name} ({Position}): {BaseSalary:N0}d");
        }
    }

    public class Department : ISalaryComponent
    {
        public string Name { get; }
        private readonly List<ISalaryComponent> _children = new List<ISalaryComponent>();

        public Department(string name) { Name = name; }

        public void Add(ISalaryComponent item) => _children.Add(item);

        public double CalculateSalary()
        {
            double total = 0;
            foreach (var item in _children) total += item.CalculateSalary();
            return total;
        }

        public void Display(int indent)
        {
            Console.WriteLine($"{new string(' ', indent * 2)}+ [PHONG BAN] {Name} - Quy luong: {CalculateSalary():N0}d");
            foreach (var item in _children) item.Display(indent + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 08: COMPOSITE LUONG NHAN VIEN ===");
            var nv1 = new Employee("Nguyen Van A", "Nhan vien Sales", 12000000);
            var tp = new Employee("Tran Van B", "Truong phong Sales", 25000000);

            var phongSales = new Department("Phong Kinh Doanh");
            phongSales.Add(tp);
            phongSales.Add(nv1);

            phongSales.Display(1);
            Console.WriteLine($"\n-> TONG QUY LUONG PHONG SALES: {phongSales.CalculateSalary():N0} VNĐ");
        }
    }
}
