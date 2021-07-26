using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

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
                        //ListRecipeNames();
                        Console.WriteLine("Enter name of recipe you would like to search for: ");
                        var searchInput = Console.ReadLine();
                        SearchRecipeName(searchInput);
                        Console.WriteLine("\nEnter 1 to go back to main menu!");
                        Console.Write("User Entry: ");
                        var backOut = Console.ReadLine();
                        if (backOut == "1")
                        {
                            secondOption = false;
                        }
                    }
                    return true;
                case "3":
                    return true;
                case "4":
                    Console.WriteLine("Good Bye!");
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

            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }

        }

        public static void SearchRecipeName(string searchInput)
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes = DeserializeRecipe();
            string recipeName;

            foreach (var recipe in recipes)
            {
                recipeName = recipe.Name;

                if (recipeName.ToLower() == searchInput.ToLower()) // Setting both the recipe name and the search input to lower case to prevent case sensitive issues.
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
                else
                {
                    Console.WriteLine("Invalid Search!");
                    break;
                }
            }
        }
    }
}
