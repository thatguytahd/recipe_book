using System;
using System.Collections.Generic;
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
    }

    public class Ingredient
    {
        public string Quantity { get; set; }
        public string Name { get; set; }
    }
}
