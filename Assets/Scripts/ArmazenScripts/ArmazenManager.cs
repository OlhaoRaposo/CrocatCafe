using UnityEngine;
using UnityEngine.UI;

public class ArmazenManager : MonoBehaviour
{
    public static ArmazenManager instance;
    public int money;
    [SerializeField] private Text moneyText;
    [SerializeField] private IngredientData[] allIngredients;
    [SerializeField] private FoodData[] allFoods;

    [SerializeField] public int[] ingredientAmmount, foodAmmount;
    [SerializeField] private Text[] ingredientText, foodText;

    private void Awake()
    {
        instance = this;
        ingredientAmmount = new int[allIngredients.Length];
        foodAmmount = new int[allFoods.Length];
        moneyText.text = $"x{money}";
    }

    public void AddIngredient(string ingredient, int ammount)
    {
        for (int i = 0; i < allIngredients.Length; i++)
        {
            if (allIngredients[i].ingredientName == ingredient)
            {
                ingredientAmmount[i] += ammount;
                UpdateIngredientText(i);
            }
        }

        //Caso o ingrediente também seja um prato
        for (int i = 0; i < allFoods.Length; i++)
        {
            if (allFoods[i].foodName == ingredient)
            {
                foodAmmount[i] += ammount;
                UpdateFoodText(i);
                return;
            }
        }
    }

    public void RemoveIngredient(string ingredient, int ammount)
    {
        for (int i = 0; i < allIngredients.Length; i++)
        {
            if (allIngredients[i].ingredientName == ingredient)
            {
                if (ingredientAmmount[i] - ammount >= 0)
                {
                    ingredientAmmount[i] -= ammount;
                    UpdateIngredientText(i);
                }
            }
        }

        //Caso o ingrediente também seja um prato
        for (int i = 0; i < allFoods.Length; i++)
        {
            if (allFoods[i].foodName == ingredient)
            {
                foodAmmount[i] -= ammount;
                UpdateFoodText(i);
                return;
            }
        }
    }

    public int IngredientAmmount(string ingredient)
    {
        for (int i = 0; i < allIngredients.Length; i++)
        {
            if (allIngredients[i].ingredientName == ingredient)
            {
                return ingredientAmmount[i];
            }
        }
        return -1;
    }

    public void AddFood(string food, int ammount)
    {
        for (int i = 0; i < allFoods.Length; i++)
        {
            if (allFoods[i].foodName == food)
            {
                foodAmmount[i] += ammount;
                UpdateFoodText(i);
            }
        }

        //Caso o prato também seja um ingrediente
        for (int i = 0; i < allIngredients.Length; i++)
        {
            if (allIngredients[i].ingredientName == food)
            {
                ingredientAmmount[i] += ammount;
                UpdateIngredientText(i);
                return;
            }
        }
    }

    public void RemoveFood(string food, int ammount)
    {
        for (int i = 0; i < allFoods.Length; i++)
        {
            if (allFoods[i].foodName == food)
            {
                if (foodAmmount[i] - ammount >= 0)
                {
                    foodAmmount[i] -= ammount;
                    UpdateFoodText(i);
                }
            }
        }

        //Caso o prato também seja um ingrediente
        for (int i = 0; i < allIngredients.Length; i++)
        {
            if (allIngredients[i].ingredientName == food)
            {
                ingredientAmmount[i] -= ammount;
                UpdateIngredientText(i);
                return;
            }
        }
    }

    public int FoodAmmount(string food)
    {
        for (int i = 0; i < allFoods.Length; i++)
        {
            if (allFoods[i].foodName == food)
            {
                return foodAmmount[i];
            }
        }
        return -1;
    }

    public FoodData[] GetAllFoods()
    {
        return allFoods;
    }

    public void SetMoney(int money)
    {
        this.money = money;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        moneyText.text = $"x{money}";
    }

    public void UpdateIngredientText(int index)
    {
        ingredientText[index].text = $"x{ingredientAmmount[index]}";
    }

    public void UpdateFoodText(int index)
    {
        foodText[index].text = $"x{foodAmmount[index]}";
    }
}
