using DrinksApp.Models;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace DrinksApp.Services;

public static class ApiHelper
{
    public static HttpClient? ApiClient { get; private set; }

    public static void InitializeClient()
    {
        ApiClient = new();
        ApiClient.BaseAddress = new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
        ApiClient.DefaultRequestHeaders.Accept.Clear();
        ApiClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    public static async Task<List<string>> GetAllCategories()
    {
        using HttpResponseMessage response = await ApiClient!.GetAsync("list.php?c=list");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();
            CategoryResponse cr = JsonConvert.DeserializeObject<CategoryResponse>(jsonResponse)!;

            List<string> Items = new();
            foreach (CategoryItem item in cr.Drinks)
            {
                Items.Add(item.Name);
            }
            return Items;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }

    public static async Task<>
}

}