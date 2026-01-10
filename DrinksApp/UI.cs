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
        Console.WriteLine("\n\n");
        AnsiConsole.MarkupLine("[bold orange3]Press Enter to Continue...[/]");
        Console.ReadKey();
    }

    #region LoadData
    public static async Task<List<string>> LoadCategories()
    {
        var _categoryMenu = new List<string>();
        if (_categoryMenu.Count == 0)
        {
            _categoryMenu!.AddRange(await ApiHelper.GetAllCategories());
            _categoryMenu.Add("Exit"); // Append an exit option to the list.
            return _categoryMenu;
        }
        else
        {
            return _categoryMenu;
        }
    }

    public static async Task<List<string>> LoadDrinks(string category)
    {
        var _drinksMenu = new List<string>();
        _drinksMenu.AddRange(await ApiHelper.GetDrinksList(category));
        _drinksMenu.Insert(0,"Back");
        return _drinksMenu;
    }
    #endregion

    #region Menu Setups
    public static async Task<string> GetCategoryChoice()
    {
        List<string> categoryMenu = await LoadCategories();

        Console.Clear();
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a menu Option:")
            .AddChoices(categoryMenu));
        return userInput;
    }

    public static async Task<string> GetDrinkChoice(string category)
    {
        List<string> drinksMenu = await LoadDrinks(category);

        Console.Clear();
        AnsiConsole.MarkupLine($"Category Selected: [bold italic orange3]{category.ToUpper()}[/]");
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a drink to view recipe:")
            .AddChoices(drinksMenu)
            .EnableSearch()
            .SearchPlaceholderText("Type to search...")
            .PageSize(15));
        return userInput;
    }

    internal static async Task<string> GetRecipeId(int recipeId)
    {
        throw new NotImplementedException();
    }
    #endregion

}