using System;

namespace Lesson_2._3
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите что-нибудь...");

            string Text = Console.ReadLine();

            string reversedText = string.Empty;

            for (int i = Text.Length - 1; i >= 0; i--)
            {
                reversedText = reversedText + Text[i];
            }

            Console.WriteLine($"Результат: {reversedText}");
        }
    }
}
