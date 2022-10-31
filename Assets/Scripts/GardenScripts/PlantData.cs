using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "New Plant")]
public class PlantData : ScriptableObject
{
    public string myName, loot;
    public int plantCode;
    public GameObject[] stages;
    public float growthTime;
}
