using Demonstration_exam_2024.Models;
using System.Linq;
using System.Data.Entity; // Добавьте эту строку

public class Example
{
    public void UseDatabase()
    {
        using (var context = new PartnerSystemContext())
        {
            // Теперь Include должен работать правильно
            var partners = context.Partners
                .Include(p => p.PartnerType)
                .ToList();

            // Пример использования
            foreach (var partner in partners)
            {
                // Доступ к данным партнера
                string partnerName = partner.Name;
                string partnerTypeName = partner.PartnerType?.TypeName;

                // Можно использовать эти данные как нужно
                System.Console.WriteLine($"Partner: {partnerName}, Type: {partnerTypeName}");
            }
        }
    }
}