using Spectre.Console;
//namespace DrinksApp.Services;
using DrinksAPI;

internal class UI
{
    public static void WelcomeMessage()
    {
        AnsiConsole.MarkupLine("[bold orange3]Welcome to the Drinks Application![/]\n");
        AnsiConsole.MarkupLine("[bold orange3]In this application you will lookup information about drinks from an external source. The menus will present several different ways to lookup/view the information.[/]");
        AnsiConsole.MarkupLine("[bold orange3]To Continue, please press Enter... [/]");
        System.Console.ReadKey();
    }

    public static async Task<string> GetMainMenuChoice()
    {
        List<string> choices = await ApiHelper.GetAllCategories();
        System.Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(choices));
        return userInput;
    }
}