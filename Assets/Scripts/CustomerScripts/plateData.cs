using UnityEngine;
using UnityEngine.UI;

public class plateData : MonoBehaviour
{
    public FoodData food;
    public GameObject plateObject;
    public Image myImage;

    public void SetData(FoodData data)
    {
        plateObject.SetActive(true);
        food = data;
        myImage.sprite = food.icon;
    }

    public void CleanData()
    {
        plateObject.SetActive(false);
        food = null;
        myImage.sprite = null;
    }
}
