using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recipe_book
{
    public class Conversion
    {
        public static void UnitConversionTool(string quantity, string initialUnit, string desiredUnit)
        {
            double convertedQuantity;

            if (Double.TryParse(quantity, out var inputDouble) == true) //check to make sure the input quantity can successfully converted from a string to a double and if not print out to try again.
            {

                if (String.IsNullOrEmpty(quantity) || String.IsNullOrEmpty(initialUnit) || String.IsNullOrEmpty(desiredUnit)) //First check that there are no empty values
                {
                    Console.WriteLine("One or more values were empty or null. Please try again!");
                }
                else if (initialUnit == "cups" && desiredUnit == "grams") //cups to grams
                {
                    double gramsPerCup = 236.5;
                    convertedQuantity = inputDouble * gramsPerCup;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else if (initialUnit == "grams" && desiredUnit == "cups") //grams to cups
                {
                    double gramsPerCup = 236.5;
                    convertedQuantity = inputDouble / gramsPerCup;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else if (initialUnit == "grams" && desiredUnit == "ounces") //grams to ounces
                {
                    double ouncesPerGram = 0.03;
                    convertedQuantity = inputDouble * ouncesPerGram;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else if (initialUnit == "ounces" && desiredUnit == "grams") // ounces to grams
                {
                    double ouncesPerGram = 0.03;
                    convertedQuantity = inputDouble / ouncesPerGram;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else if (initialUnit == "cups" && desiredUnit == "ounces") //cups to ounces
                {
                    double ouncesPerCup = 8.34;
                    convertedQuantity = inputDouble * ouncesPerCup;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else if (initialUnit == "ounces" && desiredUnit == "cups") //ounces to cups
                {
                    double ouncesPerCup = 8.34;
                    convertedQuantity = inputDouble / ouncesPerCup;
                    Console.WriteLine(ConversionPrinter(quantity, convertedQuantity, initialUnit, desiredUnit));
                }
                else //Catch all if user inputs something that doesnt match the scenarios above
                {
                    Console.WriteLine("\nUnable to read units, retry and make sure to either user \"cups\", \"ounces\", or \"grams\".");
                }
            }
            else
            {
                Console.WriteLine("Please input a quanity in a numerical format (ex. 1, 5.7, 100.25, etc)");
            }

        }

        //Attempt to make the ConversionTool DRY by having a function that returns the template for the conversion message
        public static string ConversionPrinter(string initialQuantity, double result, string firstUnit, string convertedUnit) 
        {
            var printOut = $"\n{initialQuantity} {firstUnit} is approximately {result} {convertedUnit}!";
            return printOut;
        }
    }
}
