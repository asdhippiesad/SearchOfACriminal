using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchOfACriminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriminalBase criminal = new CriminalBase();

            criminal.SetDescription();

            Console.ReadKey();
        }
    }

    class CriminalBase
    {
        List<Criminal> _criminals = new List<Criminal>
            {
                new Criminal("Аой Сато", "японка", 78, 179, true),
                new Criminal("Асанов Амир", "казах", 67, 185, false),
                new Criminal("Бато Будаев", "бурят", 65, 165, false),
                new Criminal("Чичигинаров Дьулус", "якут", 90, 190, false),
                new Criminal("Николай Ярославский", "русский", 89, 195, false),
                new Criminal("Алёна Зыкова", "русская", 86, 189, true)
            };

        public void SetDescription()
        {
            Console.WriteLine("Введите вес: ");
            string weight = Console.ReadLine();

            Console.WriteLine("Введите рост: ");
            string height = Console.ReadLine();

            if (int.TryParse(weight, out int inputWeight) && int.TryParse(height, out int inputHeight))
            {
                var filledCriminal = from Criminal criminals in _criminals
                                     where criminals.Weight == inputWeight
                                     where criminals.Height == inputHeight
                                     where criminals.IsImprisoned == false
                                     select criminals;

                if (filledCriminal.Any())
                {
                    ShowInfo(filledCriminal.ToList());
                }
            }
            else
            {
                Console.WriteLine("Данных нет");
            }
        }

        public void ShowInfo(List<Criminal> criminal)
        {
            if (criminal.Count == 0)
            {

            }
            else
            {
                foreach (Criminal criminals in criminal)
                {
                    Console.WriteLine($"имя -- {criminals.Name}.\n" +
                                      $"вес -- {criminals.Weight}.\n" +
                                      $"рост -- {criminals.Height}.\n");
                }
            }
        }
    }

    class Criminal
    {
        public string Name { get; private set; }
        public string Nationality { get; private set; }
        public int Weight { get; private set; }
        public int Height { get; private set; }
        public bool IsImprisoned { get; private set; }

        public Criminal(string name, string mationality, int weight, int height, bool imprisoned)
        {
            Name = name;
            Nationality = mationality;
            Weight = weight;
            Height = height;
            IsImprisoned = imprisoned;
        }
    }
}
