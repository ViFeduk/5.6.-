using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _5._6._Итоговый_проект
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var userInfo = Questionary();
            ShowInfo(userInfo);


        }

        static void ShowInfo((string name, string surename, int age, bool haveAPet, int numberOfPets, string[] namesPets, int numFavColor, string[] favColor) result)
        {
            Console.WriteLine($"\n\n\n\nВаше имя: {result.name}\nВаша фамилия: {result.surename}" +
                $"\nВаш возраст: {result.age}\nНаличие животного: {result.haveAPet}\nКол-во питомцев: {result.numberOfPets}" +
                $"\nКлички животных:{PrintInfoArray(result.namesPets)}\nКол-во любимых цветов: {result.numFavColor}\nЛюбимые цвета: {PrintInfoArray(result.favColor)}" );
        }
        static string PrintInfoArray(string[] arr)
        {
            if (arr != null) 
            { 
            
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < arr.Length; i++)
                {
                    builder.Append(arr[i]);
                    if (i < arr.Length - 1)
                        builder.Append(", ");
                }
                return builder.ToString();
            }
            return " ";
        }


        static string[] InputNamesPet(int numbersPets)
        {
            var namesPets = new string[numbersPets];
            for (int i = 0; i < numbersPets; i++)
            {
               namesPets[i]=Console.ReadLine();
            }
            return namesPets;
        }


        static string[] InputFavColor(int numColor)
        {
            var favColor = new string[numColor];
            for (int i = 0; i < favColor.Length; i++)
            {
               favColor[i]=Console.ReadLine();
            }
            return favColor;
        }


        static bool IsValidPositiveInteger(string input)
        {
            int value;
            return int.TryParse(input, out value) && value > 0;
        }

        static int GetValidPositiveInteger(string prompt)
        {
            int value = 0;
            bool validInput = false;

            do
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                validInput = IsValidPositiveInteger(input);

                if (validInput)
                {
                    value = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Введите корректное положительное целое число.");
                }
            } while (!validInput);

            return value;
        }



        static (string name, string surename, int age, bool haveAPet, int numberOfPets, string[] namesPets, int numFavColor, string[] favColor) Questionary()
        {
            (string name, string surename, int age, bool haveAPet, int numberOfPets, string[] namesPets, int numFavColor, string[] favColor) result = (null, null, 0, false, 0, null, 0, null);
            Console.WriteLine("Введите ваше имя");
            result.name = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию");
            result.surename = Console.ReadLine();
            
            result.age= GetValidPositiveInteger("Введите ваш возраст:");


            Console.WriteLine("У вас есть питомец? (Да/Нет)");
            
            if (Console.ReadLine().ToLower() == "да")
            {
                result.haveAPet = true;
                result.numberOfPets = GetValidPositiveInteger("Сколько у вас питомцев?");
                Console.WriteLine("Введите их клички");
                result.namesPets = InputNamesPet(result.numberOfPets);
            }

            result.numFavColor = GetValidPositiveInteger("Сколько у вас любимых цветов?");
            Console.WriteLine("Введите любимые цвета");
            result.favColor = InputFavColor(result.numFavColor);
            
            return result;



        }



    }
}
