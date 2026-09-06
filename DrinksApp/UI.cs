using DrinksAPI.Models;
using DrinksApp.Services;
using Spectre.Console;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Reflection.Emit;

public class UI
{
    #region Menu Setups
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
        List<KeyValuePair<int, string>> drinksMenuWithId = await LoadDrinks(category);
        List<string> drinksMenu = new List<string>();
        foreach (var item in drinksMenuWithId)
        {
            drinksMenu.Add(item.Value);
        }

        Console.Clear();
        AnsiConsole.MarkupLine($"Category Selected: [bold italic orange3]{category.ToUpper()}[/]");
        var userInput = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Please select a drink to view recipe:")
            .AddChoices(drinksMenu)
            .EnableSearch()
            .SearchPlaceholderText("Type to search...")
            .PageSize(15));

        // Select and return Menu Item ID based on the user's input
        if (userInput.ToLower() != "back")
        {
            //TODO - This line currently returns the recipe name, not the ID

            userInput = drinksMenuWithId.FirstOrDefault(kvp => kvp.Value == userInput).Key.ToString();
            //userInput = drinksMenuWithId.FirstOrDefault(kvp => kvp.Value == userInput).Value;

            return userInput;
        }
        else
        {
            return "Back";
        }

    }

    public static async void DisplayRecipe(string drinkChoice)
    {
        Console.Clear();
        //drinkChoice = id number
        int colCount = 0;

        // call API to get recipe from ID and load into object
        RecipeResponse recipe = await ApiHelper.GetRecipe(drinkChoice);

        // display object in table format
        var table = new Table();

        table.AddColumn("Info Type", col => col.RightAligned());
        table.AddColumn("Value", col => col.Centered());

        foreach (var property in recipe.GetType().GetProperties())
        {
            table.AddRow(property.Name.ToString(), property.GetValue(recipe).ToString() ?? "");
        }

        AnsiConsole.Write(table);
    }


    #endregion

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

    public static async Task<List<KeyValuePair<int, string>>> LoadDrinks(string category)
    {
        var _drinksMenu = new List<KeyValuePair<int, string>>();
        _drinksMenu.AddRange(await ApiHelper.GetDrinksList(category));
        _drinksMenu.Insert(0, new KeyValuePair<int, string>(_drinksMenu.Count, "Back"));
        return _drinksMenu;
    }



    #endregion

}