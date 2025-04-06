using System;
using System.Linq;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Utils
{
    /// <summary>
    /// Класс для расчета скидок партнеров на основе объема продаж
    /// </summary>
    public static class DiscountCalculator
    {
        // Пороговые значения для расчета скидок
        private const int THRESHOLD_1 = 10000;  // 5%
        private const int THRESHOLD_2 = 50000;  // 10%
        private const int THRESHOLD_3 = 300000; // 15%

        /// <summary>
        /// Рассчитывает скидку для партнера на основе общего объема продаж
        /// </summary>
        /// <param name="partnerId">ID партнера</param>
        /// <returns>Процент скидки (0, 5, 10 или 15)</returns>
        public static int CalculateDiscount(int partnerId)
        {
            try
            {
                using (var db = new DatabaseContext())
                {
                    // Получаем общий объем продаж партнера
                    var totalQuantity = db.Sales
                        .Where(s => s.PartnerId == partnerId)
                        .Sum(s => s.Quantity);

                    // Определяем процент скидки
                    if (totalQuantity > THRESHOLD_3) return 15;
                    if (totalQuantity > THRESHOLD_2) return 10;
                    if (totalQuantity > THRESHOLD_1) return 5;
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0; // В случае ошибки возвращаем 0%
            }
        }

        /// <summary>
        /// Получает текстовое описание условий скидки
        /// </summary>
        /// <returns>Строка с описанием условий</returns>
        public static string GetDiscountDescription()
        {
            return $"Скидка зависит от общего объема продаж:\n" +
                   $"До {THRESHOLD_1:N0} - 0%\n" +
                   $"От {THRESHOLD_1:N0} до {THRESHOLD_2:N0} - 5%\n" +
                   $"От {THRESHOLD_2:N0} до {THRESHOLD_3:N0} - 10%\n" +
                   $"Более {THRESHOLD_3:N0} - 15%";
        }

        /// <summary>
        /// Применяет скидку к сумме
        /// </summary>
        /// <param name="amount">Исходная сумма</param>
        /// <param name="discountPercent">Процент скидки</param>
        /// <returns>Сумма со скидкой</returns>
        public static decimal ApplyDiscount(decimal amount, int discountPercent)
        {
            return amount * (100 - discountPercent) / 100;
        }
    }
}