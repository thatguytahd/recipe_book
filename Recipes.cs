using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_book
{
    public class Rootobject
    {
        public Recipe[] Recipe { get; set; }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public Ingredient[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        // Deserialize the recipes.json so that we can interact with it and pull the information via StreamReader
        public static List<Recipe> DeserializeRecipe()
        {
            var fileName = Program.GetFullFilePath("recipes.json");
            var recipes = new List<Recipe>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                recipes = serializer.Deserialize<List<Recipe>>(jsonReader);
            }

            return recipes;
        }

        // Method to list all the recipes that exist in recipes.json
        public static void ListRecipeNames()
        {
            var recipes = new List<Recipe>();
            recipes = DeserializeRecipe();
            int counter = 1;

            foreach (var recipe in recipes)
            {
                Console.WriteLine($"{counter}.) {recipe.Name}");
                counter++;
            }

        }

        // Search method to find a certain recipe in recipes.json
        public static void SearchRecipeName(string searchInput)
        {
            var recipes = new List<Recipe>();
            recipes = DeserializeRecipe();

            bool checkIfListContains = recipes.Any(p => p.Name.ToLower() == searchInput.ToLower()); // Boolean variable to hold if the searchInput exists within the list of Recipe objects using some LINQ magic

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
    }

    public class Ingredient
    {
        public string Quantity { get; set; }
        public string Name { get; set; }
    }
}
