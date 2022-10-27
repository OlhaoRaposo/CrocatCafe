using UnityEngine;

[CreateAssetMenu(fileName = "Plant", menuName = "New Plant")]
public class PlantData : ScriptableObject
{
    public string myName, loot;
    public GameObject[] stages;
    public float growthTime;
}
