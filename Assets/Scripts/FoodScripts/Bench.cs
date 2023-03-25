using UnityEngine;
using System.Collections;

public class Bench : MonoBehaviour
{
    public RecipeData[] acceptedRecipes;
    public int selectedRecipe;
    public string managerName;
    public GameObject myObject;
    private UiLoaderScript uiLoader;

    public void Start()
    {
        if(managerName != "")
        {
            uiLoader = GameObject.Find(managerName).GetComponent<UiLoaderScript>();
        }
    }

    public void SetRecipe(int selectedRecipe)
    {
        this.selectedRecipe = selectedRecipe;
    }

    public void CookRecipe()
    {
        Cook(acceptedRecipes[selectedRecipe]);
    }

    private void Cook(RecipeData recipe)
    {
        //Checagem de ingredientes
        for (int i = 0; i < recipe.requiredIngredients.Length; i++)
        {
            if (ArmazenManager.instance.IngredientAmmount(recipe.requiredIngredients[i].ingredientName) < recipe.requiredAmmount[i])
            {
                return;
            }
        }

        //Iniciar o preparo
        for (int i = 0; i < recipe.requiredIngredients.Length; i++)
        {
            ArmazenManager.instance.RemoveIngredient(recipe.requiredIngredients[i].ingredientName, recipe.requiredAmmount[i]);
        }
        StartCoroutine(CookProcess(recipe, recipe.productionTime));
        AudioBoard.instance.PlayAudio("SFX_UI_Shop");
        uiLoader.CloseTab(uiLoader.firstUiGmbj);
    }


    //Ato de cozinhar
    private IEnumerator CookProcess(RecipeData recipe, float time)
    {
        //Esperar o gato chegar na bancada
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(myObject, (int)time);
        while (Vector3.Distance(myObject.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        //Aguardar o tempo de cozimento
        yield return new WaitForSeconds(time);

        //Adicionar o produto no final
        Debug.Log($"Adicionou {recipe.outputAmmount} {recipe.product}(s)");
        ArmazenManager.instance.AddFood(recipe.product, recipe.outputAmmount);
    }

    //Seta os dados da bench escolhida na UI
    public void OpenUI()
    {
        Bench chosenBench = uiLoader.gameObject.GetComponent<Bench>();
        chosenBench.acceptedRecipes = this.acceptedRecipes;
        chosenBench.selectedRecipe = 0;
        chosenBench.managerName = this.managerName;
        chosenBench.myObject = this.gameObject;
        chosenBench.uiLoader = this.uiLoader;

        uiLoader.OpenUi();
    }
}
