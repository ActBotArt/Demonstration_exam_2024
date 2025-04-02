using System;
using System.Linq;
using Demonstration_exam_2024.Models;

namespace Demonstration_exam_2024.Utils
{
    public static class MaterialCalculator
    {
        public static decimal CalculateMaterialCost(decimal length, decimal width)
        {
            try
            {
                // Расчет площади
                decimal area = length * width;

                // Базовая стоимость за квадратный метр
                decimal baseCostPerSquareMeter = 500;

                // Расчет базовой стоимости
                decimal baseCost = area * baseCostPerSquareMeter;

                // Если площадь больше 20 кв.м, применяем скидку 10%
                if (area > 20)
                {
                    decimal discount = baseCost * 0.1m;
                    baseCost -= discount;
                }

                // Добавляем стоимость работы (30% от стоимости материала)
                decimal laborCost = baseCost * 0.3m;

                // Итоговая стоимость
                decimal totalCost = baseCost + laborCost;

                return Math.Round(totalCost, 2);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при расчете стоимости материала: {ex.Message}");
            }
        }

        public static decimal CalculateInstallationTime(decimal area)
        {
            try
            {
                // Базовое время на установку (часов на кв.м.)
                decimal baseTimePerSquareMeter = 1.5m;

                // Расчет общего времени
                decimal totalTime = area * baseTimePerSquareMeter;

                // Если площадь больше 30 кв.м., добавляем 20% времени на сложность работы
                if (area > 30)
                {
                    totalTime *= 1.2m;
                }

                // Округляем до ближайшего получаса
                return Math.Ceiling(totalTime * 2) / 2;
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при расчете времени установки: {ex.Message}");
            }
        }

        public static (decimal TotalCost, decimal InstallationTime, string Recommendation)
            GetFullCalculation(decimal length, decimal width)
        {
            try
            {
                decimal area = length * width;
                decimal totalCost = CalculateMaterialCost(length, width);
                decimal installationTime = CalculateInstallationTime(area);

                string recommendation;
                if (area < 10)
                    recommendation = "Рекомендуется стандартная укладка";
                else if (area < 30)
                    recommendation = "Рекомендуется укладка с подложкой";
                else
                    recommendation = "Рекомендуется профессиональная укладка с подложкой и гидроизоляцией";

                return (totalCost, installationTime, recommendation);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при полном расчете: {ex.Message}");
            }
        }
    }
}