using DrinksApp.Services;

string categoryChoice;
string drinkChoice;
string recipeChoice;
ApiHelper.InitializeClient();
UI.WelcomeMessage();

while (true)
{
    // step 1 - select and display drink category
    categoryChoice = await UI.GetCategoryChoice();
    if (categoryChoice == "Exit")
        break;

    while (true)
    {
        // step 2 - select and display available drinks and return id of selected drink
        drinkChoice = await UI.GetDrinkChoice(categoryChoice);
        if (drinkChoice == "Back")
            break;
        while (true)
        {
            // step 3 - select and display the selected recipe
            UI.DisplayRecipe(drinkChoice);
        }
    }
}
