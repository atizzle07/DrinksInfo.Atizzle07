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
		drinkChoice = await UI.GetDrinkChoice(categoryChoice); // step 2 - select and display and select drink
        do
        {
            recipeChoice = await UI.GetRecipeChoice(drinkChoice); // step 3 - select and display and select recipe
        } while (drinkChoice != "Back");
    } while (drinkChoice != "Back");

} while (categoryChoice != "Exit");


