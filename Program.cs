using System;

namespace Unit5_6
{
    class Program
    {
        static void Main(string[] args)
        {

            var User = GetUser();

            DisplayUser(User);

            Console.ReadKey();
        }

        static (string, string, int, bool, int, string[], int, string[]) GetUser()
        {

            (string Name,
            string Surname,
            int Age,
            bool HasPet,
            int QuantityPet,
            string[] PetNames,
            int QuantityFavColors,
            string[] FavColors) user;

            Console.WriteLine("Ввод информации о пользователе\n------------------------------");

            // Имя;
            Console.Write("Имя: ");
            user.Name = Console.ReadLine();

            // Фамилия;
            Console.Write("Фамилия: ");
            user.Surname = Console.ReadLine();

            // Возраст;
            Console.Write("Возраст: ");
            //string userAge = int.Parse(Console.ReadLine());
            user.Age = GetValue();

            // Наличие питомца;
            Console.Write("Есть питомец: ");
            string hasPet = Console.ReadLine();
            user.HasPet = (hasPet == "да" || hasPet == "yes") ? true : false;

            user.QuantityPet = 0;
            user.PetNames = Array.Empty<string>();

            //Если питомец есть, то запросить количество питомцев;
            if (user.HasPet)
            {
                // Если питомец есть, то запросить количество питомцев;
                Console.Write("Количество питомцев: ");
                user.QuantityPet = GetValue();

                // Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек(заполнение с клавиатуры);
                user.PetNames = GetArrayOfString(user.QuantityPet, "Перечислите их клички:");
            }

            // Запросить количество любимых цветов;
            Console.Write("Количество любимых цветов: ");
            user.QuantityFavColors = GetValue();

            // Вызвать метод, который возвращает массив любимых цветов по их количеству(заполнение с клавиатуры);
            user.FavColors = GetArrayOfString(user.QuantityFavColors);

            return user;
        }

        static string[] GetArrayOfString(int numStr, in string description = "Перечислите их ниже:")
        {
            string[] str = new string[numStr];

            if (numStr > 0)
            {
                Console.WriteLine(description);

                for (int i = 0; i < numStr; i++)
                {
                    str[i] = Console.ReadLine();
                }
            }

            return str;
        }

        // Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
        static int GetValue()
        {
            string strValue = Console.ReadLine();

            if (int.TryParse(strValue, out int value))
            {
                // Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
                // Корректный ввод: ввод числа типа int больше 0.
                if (value <= 0)
                {
                    value = GetValue();
                }
                else return value;
            }
            else
            {
                value = GetValue();
            }

            return value;
        }

        static void DisplayUser((string Name, string Surname, int Age, bool HasPet, int QuantityPet, string[] PetNames, int QuantityFavColors, string[] FavColors) User)
        {
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Вывод введенной информации:\n---------------------------");

            //Имя;
            Console.WriteLine("Имя: {0}", User.Name);
            Console.WriteLine("Фамилия: {0}", User.Surname);
            Console.WriteLine("Возраст: {0}", User.Age);
            Console.WriteLine("Наличие питомца: {0}", User.HasPet.ToString());
            if (User.HasPet)
            {
                Console.WriteLine("Клички: ");
                foreach (var petName in User.PetNames)
                {
                    Console.WriteLine("		{0}", petName);
                }
            }
            Console.WriteLine("Количество любимых цветов: {0}", User.QuantityFavColors);
            Console.WriteLine("Цвета: ");
            foreach (var favColor in User.FavColors)
            {
                Console.WriteLine("		{0}", favColor);
            }
        }
    }
}
