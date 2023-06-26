using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bench : MonoBehaviour
{
    public RecipeData[] acceptedRecipes;
    public int selectedRecipe;
    public string managerName;
    public GameObject myObject, myTimer;
    public Image readyIcon;
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
        for (int i = 0; i < acceptedRecipes[selectedRecipe].requiredIngredients.Length; i++)
        {
            if (ArmazenManager.instance.IngredientAmmount(acceptedRecipes[selectedRecipe].requiredIngredients[i].ingredientName) < acceptedRecipes[selectedRecipe].requiredAmmount[i])
            {
                readyIcon.color = Color.red;
                return;
            }
        }
        readyIcon.color = Color.green;
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
                AudioBoard.instance.PlayAudio("SFX_UI_Exit");
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
        EditMode.instance.ToggleCanvas(false);
    }


    //Ato de cozinhar
    private IEnumerator CookProcess(RecipeData recipe, float time)
    {
        //Esperar o gato chegar na bancada
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(myObject, (int)time);
        cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Walking", true);
        //cat.GetComponent<AnimationPlayer>().SkipAnimation();
        while (Vector3.Distance(myObject.transform.position, cat.transform.position) >= 1)
        {
            yield return new WaitForSeconds(1);
        }

        //Aguardar o tempo de cozimento
        GameObject summonedTimer = Instantiate(myTimer, myObject.transform.position + new Vector3(0, 2, 0), Quaternion.identity, myObject.transform);
        summonedTimer.GetComponent<ProgressBar>().StartLoading(time);
        cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Cooking", true);
        cat.GetComponent<AnimationPlayer>().SkipAnimation();
        yield return new WaitForSeconds(time);

        //Adicionar o produto no final
        Debug.Log($"Adicionou {recipe.outputAmmount} {recipe.product}(s)");
        ArmazenManager.instance.AddFood(recipe.product, recipe.outputAmmount);
        cat.GetComponent<AnimationPlayer>().AddAnimation("MiaArmature|Walking", true);
        cat.GetComponent<AnimationPlayer>().SkipAnimation();
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
