using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TMPManipulateData : MonoBehaviour
{
    public GameObject[] grid;
    public string[] idArray;
    
    void Start()
    {
        System.Threading.Thread.Sleep(25);
        SaveData.LoadShopData();
        grid = GameObject.FindGameObjectsWithTag("Object");
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData.data.idObjects = "";
            for (int i = 0; i < grid.Length; i++)
            {
                SaveData.data.idObjects += grid[i].GetComponent<IObjectID>().objectId + "";
                idArray[i] = grid[i].GetComponent<IObjectID>().objectId + "";
                
                SaveData.data.idArray = idArray;
                SaveData.data.grid = grid;
            }
            SaveData.SaveShopData();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveData.data.coin += 1;
            Debug.Log("aumentou");
        }
    }
}
