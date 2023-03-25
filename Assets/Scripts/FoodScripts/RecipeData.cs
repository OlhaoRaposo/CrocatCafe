using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "New Recipe")]

public class RecipeData : ScriptableObject
{
    public string product;
    public float productionTime;
    public int outputAmmount;
    public IngredientData[] requiredIngredients;
    public int[] requiredAmmount;
}
