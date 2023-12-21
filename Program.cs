using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_12
{
    internal class Program
    {
        public static void Replace(string text, char[] str) // функция, делающая работу "Replace" + "void", только для использования, никакого "return" не понадобится
        {
            for (int i = 0; i < str.Length; i++) // i < str.Length - работает, пока счётчик i меньше общего кол-ва символов "str" в "text"
                if (str[i] == 'a') str[i] = 'b'; // если str 'a'- заменяет <<a>> на <<b>> 
        }
        static void Main(string[] args)
        {
            int x; // ввод значения для считывания с клавиатуры*
            do
            {
                try
                {
                    Console.Clear(); // Очистка консоли перед работой программы
                    Console.WriteLine("\nДобро пожаловать. Практическая работа №12");
                    Console.WriteLine("\nЗамена в предложении всех <<a>> на <<b>>\n");
                    Console.Write("\nПожалуйста, введите нужное вам предложение: ");
                    string text = Convert.ToString(Console.ReadLine());
                    char[] str = text.ToCharArray();
                    if (String.IsNullOrEmpty(text)) // Проверка на случай, если пользователь ничего не ввёл в text.
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nВ данном тексте отсутствуют какие-либо символы.");
                    }
                    else if (text.Contains("a")) // Проверка на наличие <<a>> в text через "Contains"
                    {
                        Replace(text, str); // Вызов функции "Replace"
                        text = new String(str); // инициализация
                        Console.Write("\n" + text);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nВ данном тексте отсутствует <<a>>"); // Вывод, если в тексте отсутствует <<a>>
                    }
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Возникла ошибка: " + e.Message); // вывод типа ошибки при наличии таковой
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nНажмите 1, чтобы завершить работу, или 2, чтобы продолжить.\n");
                x = Convert.ToInt32(Console.ReadLine()); // ввод с клавиатуры*
            }
            while (x == 2); // если x(введённый ответ*) равен 2, программа завершает свою работу
            Console.WriteLine("\nЗавершение работы.");
            Console.ReadKey();
        }
    }
}