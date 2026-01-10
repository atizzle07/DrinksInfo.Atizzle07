using DrinksApp.Services;

string userChoice;
bool AppExit = false;
ApiHelper.InitializeClient();
UI.WelcomeMessage();

do
{
    userChoice = await UI.GetMainMenuChoice();

} while (userChoice != "Exit Application");


