using DrinksApp.Services;
using Spectre.Console;

public class UI
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

    public static async Task<List<string>> LoadCategories()
    {
        var _menuChoices = new List<string>();
        if (_menuChoices == null)
        {
            _menuChoices!.AddRange(await ApiHelper.GetAllCategories());
            _menuChoices.Add("Exit Application"); // Append an exit clause to the list.
            return _menuChoices;
        }
        else
        {
            return _menuChoices;
        }
    }

    public static async Task<string> GetMainMenuChoice()
    {
        List<string> menuChoices = await LoadCategories();

        Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(menuChoices));
        return userInput;
    }
}