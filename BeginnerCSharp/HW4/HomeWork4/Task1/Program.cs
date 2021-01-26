using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            (string firstName, string lastName, string patronimic)[] array = {
                ("Elena","Sakurdina","Petrova"),
                ("Petr","Kadrovich","Alexandovich"),
                ("Vasiliy","Pupkin","Valilievich"),
                ("Alexandra","Cyrilenko","Sergeevna")
            };

            for (var i = 0; i < array.Length; i++)
                Console.WriteLine(GetFullName(array[i].firstName,array[i].lastName,array[i].patronimic));
            
            // Program Stop
            Console.ReadLine();
        }

        static string GetFullName(string firstName, string lastName, string patronymic) => 
            $"{firstName} {lastName} {patronymic}";
    }
}