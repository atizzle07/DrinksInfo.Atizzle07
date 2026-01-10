using DrinksApp.Services;

string categoryChoice;
string drinkChoice;
string recipeChoice;
ApiHelper.InitializeClient();
UI.WelcomeMessage();

do
{
    categoryChoice = await UI.GetCategoryChoice();
	do
	{
		drinkChoice = await UI.GetDrinkChoice(categoryChoice);
        do
        {
            recipeChoice = await UI.GetRecipeId(recipeId);
        } while (drinkChoice != "Back");
    } while (drinkChoice != "Back");

} while (categoryChoice != "Exit");


