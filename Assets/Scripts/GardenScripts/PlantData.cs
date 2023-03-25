using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "New Plant")]
public class PlantData : ScriptableObject
{
    public string myName;
    public IngredientData loot;
    public int plantCode, lootAmmount, price;
    public GameObject[] stages;
    public float growthTime;
}
