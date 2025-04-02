using System.Linq;

namespace Demonstration_exam_2024.Utils
{
    public static class DiscountCalculator
    {
        public static int CalculateDiscount(int partnerId)
        {
            using (var db = new DatabaseContext())
            {
                var totalQuantity = db.Sales
                    .Where(s => s.PartnerId == partnerId)
                    .Sum(s => s.Quantity);

                if (totalQuantity > 300000) return 15;
                if (totalQuantity > 50000) return 10;
                if (totalQuantity > 10000) return 5;
                return 0;
            }
        }
    }
}