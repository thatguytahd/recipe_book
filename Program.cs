using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace recipe_book
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;

            while (isActive)
            {
                isActive = MainMenu(); // starts the show!
            }
        }

        public static string GetFullFilePath(string name)
        {
            //Getting working directory for the desired filename in the method's parameter in order to keep thing DRY
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var filePath = Path.Combine(directory.FullName, name);

            return filePath;
        }

        public static void DisplayMainMenuTxt()
        {
            var fileName = GetFullFilePath("mainMenu.txt"); //Getting full filepath of txt file for the menu

            using (var reader = new StreamReader(fileName))
            {
                string ln;
                //Loop through the txt and print out the txt line by line until there is nothing left in the file
                while ((ln = reader.ReadLine()) != null)
                {
                    Console.WriteLine(ln);
                }
            }
        }

        //Method to run the display menu txt method and contain the switch case for the main menu
        public static bool MainMenu()
        {
            Console.Clear();
            DisplayMainMenuTxt();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1": // Option to list all recipes in the recipes.json
                    bool firstOption = true;
                    while (firstOption)
                    {
                        Console.Clear();
                        Recipe.ListRecipeNames();

                        Console.WriteLine("\nEnter 1 to go back to main menu!");
                        Console.Write("User Entry: ");
                        var backOut = Console.ReadLine();
                        if (backOut == "1")
                        {
                            firstOption = false;
                        }
                    }
                    return true;
                case "2": // Option to search for a specific recipe (it is not case scpeific but needs to match the name of recipe that exists in the json)
                    bool secondOption = true;
                    while (secondOption)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name of recipe you would like to search for: ");
                        var searchInput = Console.ReadLine();
                        Recipe.SearchRecipeName(searchInput);
                        Console.WriteLine("\nPress Enter to search for another recipe.");
                        Console.WriteLine("Enter 1 to go back to main menu!");
                        Console.Write("User Entry: ");
                        var backOut = Console.ReadLine();
                        if (backOut == "1")
                        {
                            secondOption = false;
                        }
                    }
                    return true;
                case "3": // Unit Conversion Tool for converting certain measuring units to a different measuring unit
                    bool thirdOption = true;
                    while (thirdOption)
                    {
                        Console.Clear();
                        Console.WriteLine("----- Unit Conversion Tool -----");
                        Console.WriteLine("Enter quantity of unit you want to convert (ex. 1/2 needs to input as 0.5): ");
                        var quantityInput = Console.ReadLine();
                        Console.WriteLine("Enter unit you are wanting to convert from (ex. cups, ounces, or grams): ");
                        var initialUnitInput = Console.ReadLine();
                        Console.WriteLine("Enter the desired unit you are wanting to convert to (ex. cups, ounces, or grams): ");
                        var desiredUnitInput = Console.ReadLine();

                        Conversion.UnitConversionTool(quantityInput, initialUnitInput.ToLower(), desiredUnitInput.ToLower());

                        Console.WriteLine("\nPress Enter to do another unit conversion.");
                        Console.WriteLine("Enter 1 to go back to main menu!");
                        Console.Write("User Entry: ");
                        var backOut = Console.ReadLine();
                        if (backOut == "1")
                        {
                            thirdOption = false;
                        }
                    }
                    return true;
                case "4": // Option to quit out of the loop and close the program
                    Console.WriteLine("Exiting App....Good Bye!");
                    return false;
                default:
                    return true;
            }
        }
        
    }
}
