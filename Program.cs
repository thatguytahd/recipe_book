﻿using Newtonsoft.Json;
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
                isActive = MainMenu();
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
                case "1":
                    bool firstOption = true;
                    while (firstOption)
                    {
                        Console.Clear();
                        ListRecipeNames();

                        Console.WriteLine("\nEnter 1 to go back to main menu!");
                        Console.Write("User Entry: ");
                        var backOut = Console.ReadLine();
                        if (backOut == "1")
                        {
                            firstOption = false;
                        }
                    }
                    return true;
                case "2":
                    bool secondOption = true;
                    while (secondOption)
                    {
                        Console.Clear();
                        Console.WriteLine("Enter name of recipe you would like to search for: ");
                        var searchInput = Console.ReadLine();
                        SearchRecipeName(searchInput);
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
                case "3":
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

                        UnitConversionTool(Convert.ToDouble(quantityInput), initialUnitInput.ToLower(), desiredUnitInput.ToLower());

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
                case "4":
                    Console.WriteLine("Exiting App....Good Bye!");
                    return false;
                default:
                    return true;
            }
        }
        public static List<Recipe> DeserializeRecipe()
        {
            var fileName = GetFullFilePath("recipes.json");
            var recipes = new List<Recipe>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                recipes = serializer.Deserialize<List<Recipe>>(jsonReader);
            }

            return recipes;
        }

        public static void ListRecipeNames()
        {
            List<Recipe> recipes = new List<Recipe>(); 
            recipes = DeserializeRecipe();
            int counter = 1;

            foreach (var recipe in recipes)
            {
                Console.WriteLine($"{counter}.) {recipe.Name}");
                counter++;
            }

        }

        public static void SearchRecipeName(string searchInput)
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes = DeserializeRecipe();

            bool checkIfListContains = recipes.Any(p => p.Name.ToLower() == searchInput.ToLower()); // Boolean variable to hold if the searchInput exists within the list of Recipe objects
            
            if (checkIfListContains == true) //First check if the searchInput is contained within the recipes list and if not print out Invalid Search
            {
                foreach (var recipe in recipes)
                {
                    if (searchInput.ToLower() == recipe.Name.ToLower())
                    {
                        Console.Clear();
                        Console.WriteLine("The recipe you have chosen:");
                        Console.WriteLine(recipe.Name);
                        Console.WriteLine("\n\t---- Ingredients ----");
                        Ingredient[] recipeIngredients = recipe.Ingredients;
                        foreach (var ingredient in recipeIngredients)
                        {
                            Console.WriteLine($"\tQuantity: {ingredient.Quantity}");
                            Console.WriteLine($"\tIngredient: {ingredient.Name}");
                        }
                        Console.WriteLine("\n\t---- Steps ----");
                        string[] recipeSteps = recipe.Steps;
                        int stepCounter = 1;
                        foreach (var step in recipeSteps)
                        {
                            Console.WriteLine($"\tStep {stepCounter}: {step}");
                            stepCounter++;
                        }
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"{searchInput} does not exist in the Recipe Book, please try again!");
            }
            
        }

        public static void UnitConversionTool(double quantity, string initialUnit, string desiredUnit)
        {
            double convertedQuantity;

            if(initialUnit == "cups" && desiredUnit == "grams")
            {
                double gramsPerCup = 236.5;
                convertedQuantity = quantity * gramsPerCup;
                Console.WriteLine($"\n{quantity} cup(s) is approximately {convertedQuantity} grams!");
            }
            else if (initialUnit == "grams" && desiredUnit == "cups")
            {
                double gramsPerCup = 236.5;
                convertedQuantity = quantity / gramsPerCup;
                Console.WriteLine($"\n{quantity} grams is approximately {convertedQuantity} cup(s)!");
            }
            else if (initialUnit == "grams" && desiredUnit == "ounces")
            {
                double ouncesPerGram = 0.03;
                convertedQuantity = quantity * ouncesPerGram;
                Console.WriteLine($"\n{quantity} grams is approximately {convertedQuantity} ounce(s)!");
            }
            else if (initialUnit == "ounces" && desiredUnit == "grams")
            {
                double ouncesPerGram = 0.03;
                convertedQuantity = quantity / ouncesPerGram;
                Console.WriteLine($"\n{quantity} ounce(s) is approximately {convertedQuantity} grams!");
            }
            else if (initialUnit == "cups" && desiredUnit == "ounces")
            {
                double ouncesPerCup = 8.34;
                convertedQuantity = quantity * ouncesPerCup;
                Console.WriteLine($"\n{quantity} cup(s) is approximately {convertedQuantity} ounces!");
            }
            else if (initialUnit == "ounces" && desiredUnit == "cups")
            {
                double ouncesPerCup = 8.34;
                convertedQuantity = quantity / ouncesPerCup;
                Console.WriteLine($"\n{quantity} ounce(s) is approximately {convertedQuantity} cups!");
            }
            else
            {
                Console.WriteLine("\nUnable to read units, retry and make sure to either user \"cups\", \"ounces\", or \"grams\".");
            }
        }
    }
}
