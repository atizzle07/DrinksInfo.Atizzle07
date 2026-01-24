using DrinksApp.Services;

string categoryChoice;
string drinkChoice;
string recipeChoice;
ApiHelper.InitializeClient();
UI.WelcomeMessage();

do
{
    categoryChoice = await UI.GetCategoryChoice(); // step 1 - select and display drink category
    do
	{
		drinkChoice = await UI.GetDrinkChoice(categoryChoice); // step 2 - select and display available drinks and return id of selected drink
        do
        {
            recipeChoice = await UI.DisplayRecipe(drinkChoice); // step 3 - select and display and select recipe
        } while (drinkChoice != "Back");
    } while (drinkChoice != "Back");

} while (categoryChoice != "Exit");


