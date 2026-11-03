using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_Singleton
{
    public sealed class DatabaseConnection
    {
        private static DatabaseConnection _instance;
        private static readonly object _lock = new object();
        private DatabaseConnection() { }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    return _instance ??= new DatabaseConnection();
                }
            }
        }

        public void Connect() => Console.WriteLine("Da ket noi Database duy nhat.");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== P01: SINGLETON PATTERN ===");
            var db1 = DatabaseConnection.Instance;
            var db2 = DatabaseConnection.Instance;
            db1.Connect();
            Console.WriteLine($"Cung instance: {object.ReferenceEquals(db1, db2)}");
        }
    }
}
