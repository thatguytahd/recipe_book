# **C# Recipe Book Console App**

This is my project for the May 2021 C# Code Louisville Session.

A brief summary of this project is that it is a concole app that acts as a recipe book for 
cooking. When compiling the project you are faced with a master loop where you have 4 different options
available to you. The first option is display all the current recipes contained within the recipes.json
file where I have stored 3 different complete recipes for testing. The second option is to search the
recipes.json file for specific recipe and must be an exact match of an existing recipe (not case sensative
though). The third option is a unit converstion tool to convert mesauring units (cups, grams, and ounces) to
a different unit (ex. cups to grams, ounces to cups, etc). I added in tests to ensure that you are entering a numerical
value for quantity and that units match the test cases within the conversion method. The fourth option is to simply
exit the application and close the console. Each option gives you the opportunity to run the same option again to either
search for a different recipe or convert another measuring amount or enter 1 to go back to main menu to pick a different
option or quit the app.


### **Featured List**

1.) Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program.

2.) Read data from an external file, such as text, JSON, CSV, etc and use that data in your application.

3.) Build a conversion tool that converts user input to another type and displays it (ex: converts cups to grams).


### **Instructions for running the project**

After cloning the repo you will want to open the solution file (.sln) in Visual Studio and CTRL + F5 to run the program.
