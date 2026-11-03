using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPM235428_REAL_QuyTacKhuyenMai
{
    public interface IPromotionExpression { bool Interpret(string context); }

    public class VipExpression : IPromotionExpression
    {
        public bool Interpret(string context) => context.Contains("VIP");
    }

    public class MinAmountExpression : IPromotionExpression
    {
        public bool Interpret(string context) => context.Contains("OVER_1M");
    }

    public class AndExpression : IPromotionExpression
    {
        private readonly IPromotionExpression _e1;
        private readonly IPromotionExpression _e2;
        public AndExpression(IPromotionExpression e1, IPromotionExpression e2) { _e1 = e1; _e2 = e2; }
        public bool Interpret(string context) => _e1.Interpret(context) && _e2.Interpret(context);
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL 15: INTERPRETER PROMOTION RULE ===");
            var isVip = new VipExpression();
            var isOver1M = new MinAmountExpression();
            var vipAndOver1M = new AndExpression(isVip, isOver1M);

            string customerContext = "Khach hang: VIP, Don hang: OVER_1M";
            Console.WriteLine($"Du dieu kien giam 20%? {vipAndOver1M.Interpret(customerContext)}");
        }
    }
}
