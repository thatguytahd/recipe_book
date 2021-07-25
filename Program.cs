using System;
using System.IO;

namespace recipe_book
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;

            while(isActive)
            {
                DisplayMainMenu();
                string userInput = Console.ReadLine();

                Console.WriteLine($"Your input: {userInput}");

                if (userInput.ToLower() == "quit")
                {
                    Console.WriteLine("Closing App... Goodbye!");
                    isActive = false;
                }

            }
        }

        public static void DisplayMainMenu()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "mainMenu.txt");

            using (var reader = new StreamReader(fileName))
            {
                string ln;

                while ((ln = reader.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                }
            }

        }
    }
}
