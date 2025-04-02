using System;
using System.Data.SqlClient;

namespace Demonstration_exam_2024.Utils
{
    public class DiscountCalculator
    {
        public static decimal CalculateDiscount(DatabaseContext db, int partnerId)
        {
            try
            {
                string query = @"SELECT COUNT(*) 
                               FROM Sales 
                               WHERE PartnerId = @PartnerId 
                               AND SaleDate >= DATEADD(month, -1, GETDATE())";

                SqlParameter parameter = new SqlParameter("@PartnerId", partnerId);

                int salesCount = Convert.ToInt32(db.ExecuteScalar(query, new[] { parameter }));

                // Расчет скидки на основе количества продаж
                if (salesCount > 10)
                    return 0.15m; // 15% скидка
                else if (salesCount > 5)
                    return 0.10m; // 10% скидка
                else if (salesCount > 0)
                    return 0.05m; // 5% скидка

                return 0m; // Нет скидки
            }
            catch (Exception)
            {
                return 0m; // В случае ошибки возвращаем 0
            }
        }
    }
}