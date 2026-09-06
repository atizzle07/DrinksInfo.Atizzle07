using Newtonsoft.Json;
using System.Diagnostics.Metrics;

namespace DrinksAPI.Models;

public class RecipeResponse
{
    [JsonProperty("idDrink")] public int Id { get; set; }

    [JsonProperty("strDrink")] public string? DrinkName { get; set; }

    [JsonProperty("strCategory")] public string? Category { get; set; }

    [JsonProperty("strGlass")] public string? Glass { get; set; }

    [JsonProperty("strInstructions")] public string? InstructionsText { get; set; }

    public List<IngredientMeasurement>? IngredientList { get; set; }
}