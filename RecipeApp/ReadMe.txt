
GIT LINK- https://github.com/RJ9292/RecipeApp.git

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

Part 1 Updates
From the comments you made I have implemented the following:
- More relevant references
- Changed the project to .NET Framework 4.8
- Implemented necessary exceptions to methods as well as appropriate messages
- Measurements scale correctly ensuring that teaspoons convert to tablespoons, tablespoons to cups. Millilitres to litres. Grams to kilograms.
- After some time I got the scaling to work with those measurements and reset all measurements to original values.
- I made sure to add a confirmation when deleting a recipe. The user will need to type yes/no when they select delete selected recipe.
- I have added the necessary end of method lines, end of file lines and classes are split into their own folder labelled logically. More meaningful comments were added to the code to explain the methods and functions.

///////////////////////////////////////////////////////////////////////// END OF UPDATES ///////////////////////////////////////////////////////////////////////////////////////////

Part 2 Application Loading
- Once you have downloaded the file and selected the .sln file, the programme should open in Visual Studio 2022. Once that has opened simply press the Start button underneath the navigation.
- You will then be greeted with an explanation and definition of calories and food groups as well as an example of the food groups which you could select in the recipe.
- Simply follow the instructions and press enter. After you will be shown a menu with options to choose from.
- Choose an option to the corresponding number, type that number into the console.

Option 1 Enter A Recipe
- It will ask you to input a name for your recipe and you are able to choose the same name as an already existing recipe an infinite amount of times.
- After that, you will be told you can type "back" at any point in the process to return to the main menu.
- You will then need to enter the total amount of ingredients that you want.
- You will then need to enter the name of the ingredient, then the quantity of the ingredient (250) for example.
- Then after that you will be asked for the measurement of the quantity and try to stick to teaspoons, tablespoons, cups, grams, kilograms, millilitres, litres
- After you will need to select an option of the given food groups to the corresponding number.
- Lastly, you will need to enter the calories for the ingredient.
- Repeat that process for the number of ingredients you want to enter.

- You will then be asked "How many steps do you want to enter?"
- Then type in the steps which you want to add to the recipe.
- After that your recipe will be added to the system and you will be brought back to the main menu when you press enter.

Option 2 Prefill Pancake Recipe
- This will automatically input a recipe for a pancake which is helpful for testing the application and playing around with.
- Just select 2 and it will fill out the pancake recipe and press enter to go back to the main menu.

Option 3 Prefill Ciabatta Bread Recipe
- This will automatically input a recipe for Ciabatta Bread because Ciabatta Bread is the best type of bread.
- This is helpful in coordination with the pancake recipe to check requirements with multiple recipes.

Option 4 Select a Recipe
- This is where you will select a recipe you have already entered or choose one of the prefill recipes.
- The recipes you have created will all be displayed here in alphabetical order and just choose the number corresponding to the recipe which you want
- You will then be brought to a second menu.

Manage Selected Recipes
- It will display the recipe you have selected at the top and will be given 5 different options.

Option 1 Manage Selected Recipe - Change Measurements
- Here you will be able to change the quantity of the recipe's ingredients.
- You can choose from the examples or enter your own multiplier but it is best to check the recipe beforehand.
- You will then be brought back to the Manage Selected Recipe Menu.

Option 2 Manage Selected Recipe - Reset Measurements
- Here it will just reset the quantity of the recipe's ingredients back to the original values.
- After you will need to press enter to be brought back to the Manage Selected Recipe Menu.

Option 3 Manage Selected Recipe - Print Recipe
- This will print the recipe for you.
- This will be shown in a neat format showing you the name of the recipe. The ingredients with all of its values.
The steps which are numbered and lastly a total calorie counter. A warning message will appear if the recipe exceeds 300 calories with a funny little joke. Please don't take it to heart.
- You can then press enter to return back to the Manage Selected Recipe Menu.

Option 4 Manage Selected Recipe - Delete Recipe
- If you would like to delete the recipe from the system select number 4.
- You will then be asked "Are you sure you want to delete this recipe? (yes/no)"
- If you select no then it will bring you back to the Manage Selected Recipe
- If you select yes then it will delete the recipe from the system and you will be brought back to the main menu.

Option 5
- After you are done looking at the application you can press 5 and it will exit you from the application.

//////////////////////////////////////////////////////////////// END OF EXPLAINING APPLICATION ////////////////////////////////////////////////////////////////////////////////

Explaining Code and Methods

Program.cs
- The program has a Main method, Starting off we have simple commands which set the colour of the background and foreground and then a Console.Clear(); which will allow it to set for the entire application.
- DisplayExplanations(); is the first method which the user will receive which will explain the calories and the food groups.
- A list from recipe will be used which was required from us.
- Then a bool which is set false followed by a while loop which will carry out the application.
- Inside of the while the console will clear in case of anything being in the console. Then the user will be prompted with their selection. The user's selection is used in string choice and read by Console.ReadLine.
- The entirety of the user's inputs will be wrapped in a try and catch for exception handling.
- A switch case will be used with its input variable being a choice which the user will input.
- Case 1 will handle the input of the user. The recipe name will be taken and used in the newRecipe method from the recipe class. Then they will input the recipe and the case will break and bring them back to the main menu.
- Case 2 will handle the prefill for the pancake. Calling the method from the recipe class.
- Case 3 will handle the prefill for ciabatta bread. This will also call the method from the recipe class.
- Case 4 is a case where it will call recipes created and they will all be displayed in alphabetical order.
- Case 5 will be exit = true which will break the while loop which takes down the entire program.
- In the case of a person making a wrong selection the default will be set as Console.WriteLine("Incorrect Selection")
- The catch will have a standard exception statement which will say that an error has occurred.

- There will only be 2 methods which would be in the program class just for convenience.
- The first method will be DisplayExplanations which will display the information about calories and food groups. This is called at the beginning of the program class.

- The next would be SelectRecipe which will check the list of recipes if there are any recipes within a for loop, if there are no recipes it will state that there aren't any in the system.
- if there are recipes it will sort through the recipes and use a sort function using r1 and r2 to loop through each one comparing the name of each, sorting them in alphabetical order.
- With the help of a ParseInt will check if the selection is larger than 0 and if not then it will notify that you have made a wrong selection.

- The next menu is basically identical to the first one, calling the recipe list and having a bool which is set to false.
- A simple message is displayed within a while loop including for clarity the name of the recipe that they selected at the top.
- Case 1 calls the multiplier method within the multiplier class and provides them with examples of multiples they can use but I allowed them to choose any multiplier that they want.
To include decimals I had to make use of the function Globalization.NumberStyles.
- If they select the incorrect value type it will tell them they have input an "Invalid multiplier value."
- Case 2 calls the ResetValues method from the recipe class. This will just take the original value from the list and replace the values whether they have changed anything or not.
- Case 3 calls the PrintRecipe method which will print the selected recipe in a neat and good-looking format.
- The Color.ForegroundColor is used because I have had problems with the colour being affected when printing the recipe.
- Case 4 has the Remove method which is played within an if statement. This statement will receive the input "yes" for the function to be carried out so that there are no accidental deletes of recipes.
- Case 5 is going to simply be an exit out of that menu to go back to the main menu making the value equal to true.
- This is all wrapped within a try and catch for an exception and will have an error message if there are any errors.

- lastly there is a method which will make the user exit back to the method if they press enter.

/////////////////////////////////////////////////////////////////////////////END OF PROGRAM.CS//////////////////////////////////////////////////////////////////////////////

UPDATES WHICH I WANT TO IMPLEMENT
- Application doesn't allow you to undo something/ go back to the previous selection when entering a recipe
- Allow user to edit recipes which they have already made.
- When the user makes a change such as a multiplier or resets the values, it prints the recipe

References:
ankita_saini, 2019. GeeksForGeeks. [Online]
Available at: https://www.geeksforgeeks.org/console-class-in-c-sharp/
[Accessed 30 05 2024].
ankita_saini, 2023. GeeksForGeeks. [Online]
Available at: https://www.geeksforgeeks.org/c-sharp-dictionary-with-examples/
[Accessed 30 05 2024].
Kirti_Mangal, 2022. GeeksForGeeks. [Online]
Available at: https://www.geeksforgeeks.org/c-sharp-list-class/
[Accessed 30 05 2024].
ManasiKirloskar, 2021. GeeksForGeeks. [Online]
Available at: ManasiKirloskar
[Accessed 30 05 2024].
soumikmondal, 2021. GeeksForGeeks. [Online]
Available at: https://www.geeksforgeeks.org/c-sharp-delegates/
[Accessed 30 05 2024].
