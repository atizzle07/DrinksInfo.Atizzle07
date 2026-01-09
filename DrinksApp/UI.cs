using DrinksApp.Services;
using Spectre.Console;

internal class UI
{
    List<string> menuChoices = new();
    public static void WelcomeMessage()
    {
        Rule rule = new();
        rule.Border = BoxBorder.Heavy;
        var figlet = new FigletText("DRINKS LOOKUP")
        {
            Justification = Justify.Center,
            Color = Color.White,
        };

        AnsiConsole.Write(rule);
        AnsiConsole.Write(figlet);
        AnsiConsole.Write(rule);
        Console.WriteLine("\n\n\n");
        AnsiConsole.MarkupLine("[bold orange3]Press Enter to Continue...[/]");
        Console.ReadKey();
    }

    public async void LoadCategories()
    {
         menuChoices = await ApiHelper.GetAllCategories();
    }

    public async Task<string> GetMainMenuChoice()
    {
        Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(menuChoices));
        return userInput;
    }
}