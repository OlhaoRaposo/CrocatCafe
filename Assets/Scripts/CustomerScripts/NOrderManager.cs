using UnityEngine;
using System.Collections.Generic;

public class NOrderManager : MonoBehaviour
{
    public static NOrderManager instance;
    public List<FoodData> allOrders;
    public plateData[] foodIcons;

    private void Awake()
    {
        allOrders = new List<FoodData>();
    }

    private void Start()
    {
        instance = this;
    }

    public void AddOrder(FoodData data)
    {
        allOrders.Add(data);
        UpdateIcons();
    }

    public void RemoveOrder(FoodData data)
    {
        if(allOrders.Contains(data) == true)
        {
            allOrders.Remove(data);
            UpdateIcons();
        }
    }

    public void RemoveAllOrders()
    {
        foreach (FoodData order in allOrders)
        {
            RemoveOrder(order);
        }
    }

    private void UpdateIcons()
    {
        for (int i = 0; i < foodIcons.Length; i++)
        {
            if (allOrders.Count - i > 0)
            {
                foodIcons[i].SetData(allOrders[allOrders.Count - i - 1]);
            }
            else
            {
                foodIcons[i].CleanData();
            }
        }
    }
}
