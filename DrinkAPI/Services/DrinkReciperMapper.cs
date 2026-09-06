using DrinksAPI.Models;

namespace DrinksAPI.Services;

public class DrinkRecipeMapper
{
    public static RecipeResponse ReturnRecipeData(RecipeDTO dto)
    {
        if (dto == null)
        {
            throw new ArgumentNullException(nameof(dto));
        }
        else
        {
            RecipeResponse response = new RecipeResponse();
            response.Id = dto.Id;
            response.DrinkName = dto.DrinkName;
            response.Category = dto.Category;
            response.Glass = dto.Glass;
            response.InstructionsText = dto.InstructionsText;

            List<IngredientMeasurement> returnList = new();

            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient1, Measurement = dto.Measure1 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient2, Measurement = dto.Measure2 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient3, Measurement = dto.Measure3 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient4, Measurement = dto.Measure4 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient5, Measurement = dto.Measure5 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient6, Measurement = dto.Measure6 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient7, Measurement = dto.Measure7 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient8, Measurement = dto.Measure8 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient9, Measurement = dto.Measure9 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient10, Measurement = dto.Measure10 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient11, Measurement = dto.Measure11 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient12, Measurement = dto.Measure12 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient13, Measurement = dto.Measure13 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient14, Measurement = dto.Measure14 });
            returnList.Add(new IngredientMeasurement() { Ingredient = dto.Ingredient15, Measurement = dto.Measure15 });

            foreach (var item in returnList)
            {
                if (item.Ingredient != "null") // Don't need to check for nulls in measurements. A measurement without an ingredient is useless info
                {
                    response?.IngredientList?.Add(item);
                }
            }
            return response;
        }
    }
}
