using static System.Console;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts =new string[5,2]
            {
                {"Fedor", "+7 934 123 12 34"},
                {"Stepan", "stepan123@gmail.com"},
                {"Ulia", "+5 324 112 33 54"},
                {"Marina", "marina27@mail.bk"},
                {"Alex", "+1 234 456 76 23"},
            };

            for (var i = 0; i < contacts.GetLength(0); i++)
            {
                for (var j = 0; j < contacts.GetLength(1); j++)
                    Write(contacts[i, j] + " ");
                WriteLine();
            }

            // Program stop
            ReadLine();
        }
    }
}