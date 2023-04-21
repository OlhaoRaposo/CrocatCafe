using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Food", menuName = "New Food")]
public class FoodData : ScriptableObject
{
    public string foodName;
    public Sprite icon;
}
