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
                else if (userInput == "1")
                {
                    Console.WriteLine("All Recipe Names:");
                    ListRecipeNames();
                }

            }
        }

        public static string GetFullFilePath(string name)
        {
            //Getting working directory and getting the path for the mainMenu.txt
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var filePath = Path.Combine(directory.FullName, name);

            return filePath;
        }

        public static void DisplayMainMenu()
        {
            var fileName = GetFullFilePath("mainMenu.txt");

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
    }
}
