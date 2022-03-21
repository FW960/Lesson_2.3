using System;
using System.IO;
using System.Text;

namespace Lesson_2._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FilePath1 = @"C:\Users\windo\source\repos\Lesson_2.3\Lesson_2.3\Lesson_2.3\FullNameAndEmail.txt";

            string FilePath2 = @"C:\Users\windo\source\repos\Lesson_2.3\Lesson_2.3\Lesson_2.3\OnlyEmails.txt";

            string Data = @"Кучма Андрей Витальевич & Kuchma@mail.ru Мизинцев Павел Николаевич & Pasha@mail.ru";

            FileStream FileStream = new FileStream(FilePath1, FileMode.OpenOrCreate);

            FileStream.Close();

            FileStream FileStream2 = new FileStream(FilePath2, FileMode.OpenOrCreate);

            FileStream2.Close();

            File.WriteAllText(FilePath1, Data);

            string Email = File.ReadAllText(FilePath1);

            SearchEmail(ref Email);

            File.WriteAllText(FilePath2, Email);
        }

        public static void SearchEmail(ref string Email)
        {
            string Example2 = Email;

            Email = string.Empty;

            for (int i = 0; i < Example2.Length; i++)
            {
                if (Example2[i] == '&')
                {
                    for (int j = i+2; j < Example2.Length; j++)
                    {
                        if (Example2[j] == ' ')
                        {
                            j = Example2.Length;

                            Email = $"{Email} ";

                            continue;
                        }
                        else
                        {
                            Email = Email + Example2[j];
                        }
                        
                    }
                }

            }


        }
    }
}
