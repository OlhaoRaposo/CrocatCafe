using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public static string shopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/data";
    public static PlayerData data;

    public static void SetData(PlayerData dt)
    {
        data = dt;
    }
    public static void SaveShopData()
    {
        if (!Directory.Exists(shopPath))
        {
            Directory.CreateDirectory(shopPath);
        }
        string json = "";
        json += JsonUtility.ToJson(data, true);
        File.WriteAllText(shopPath + "/data.json" , json);
    }
    public static void LoadShopData()
    {
        if (!File.Exists(shopPath + "/data.json"))
        {
            SaveShopData();
        }
        string json = File.ReadAllText(shopPath + "/data.json");
        PlayerData pdata = ScriptableObject.CreateInstance<PlayerData>();
        JsonUtility.FromJsonOverwrite(json,pdata);
        data = pdata;
    }

    
    
    
}
