using DrinksAPI.Models;

namespace DrinksAPI.Services;

public class DrinkReciperMapper
{




    public static List<Ingredient>? ConvertRecipeData(RecipeDTO dto)
    {
        if (dto == null)
        {
            return null;
        }
        else
        {
            List<Ingredient> returnList = new();

            returnList.Add(new Ingredient() { Name = dto.Ingredient1, Measurement = dto.Measure1 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient2, Measurement = dto.Measure2 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient3, Measurement = dto.Measure3 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient4, Measurement = dto.Measure4 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient5, Measurement = dto.Measure5 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient6, Measurement = dto.Measure6 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient7, Measurement = dto.Measure7 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient8, Measurement = dto.Measure8 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient9, Measurement = dto.Measure9 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient10, Measurement = dto.Measure10 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient11, Measurement = dto.Measure11 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient12, Measurement = dto.Measure12 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient13, Measurement = dto.Measure13 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient14, Measurement = dto.Measure14 });
            returnList.Add(new Ingredient() { Name = dto.Ingredient15, Measurement = dto.Measure15 });

            foreach (var item in returnList)
            {
                if (item.Name == "null" && item.Measurement == "null")
                {
                    returnList.Remove(item);
                }
            }

            return returnList;
        }
    }
}
