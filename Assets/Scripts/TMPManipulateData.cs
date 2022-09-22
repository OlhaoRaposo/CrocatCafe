using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TMPManipulateData : MonoBehaviour
{
    public PlayerData data;
    public GameObject[] grid = new GameObject[2];
    void Start()
    {
        System.Threading.Thread.Sleep(25);
        SaveData.Load();
        grid = GameObject.FindGameObjectsWithTag("Object");
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData.data.idObjects = "";
            for (int i = 0; i < grid.Length; i++)
            {
                SaveData.data.idObjects += grid[i].GetComponent<IObjectID>().objectId + ",";
            }
            SaveData.Save();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SaveData.data.coin += 1;
            Debug.Log("aumentou");
        }
    }
}
