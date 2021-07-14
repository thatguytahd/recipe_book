using System;

namespace recipe_book
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;

            while(isActive)
            { 
                Console.WriteLine("Hello and Welcome to THE Recipe Book Console App!");
                Console.WriteLine("");
                Console.WriteLine("Please slect one of the following menu items:");
                Console.WriteLine("1.) List all available recipes");
                Console.WriteLine("2.) Search for a specific recipe name");
                Console.WriteLine("3.) Conversion Tool");
                Console.Write("Enter Selection: ");
                string userInput = Console.ReadLine();

                Console.WriteLine($"Your input: {userInput}");

                if (userInput.ToLower() == "quit")
                {
                    Console.WriteLine("Closing App... Goodbye!");
                    isActive = false;
                }

            }
        }
    }
}
