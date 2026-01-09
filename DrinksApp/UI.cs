using DrinksApp.Services;
using Spectre.Console;

internal class UI
{
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

    public static async Task<string> GetMainMenuChoice()
    {
        List<string> choices = await ApiHelper.GetAllCategories();
        Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(choices));
        return userInput;
    }
}