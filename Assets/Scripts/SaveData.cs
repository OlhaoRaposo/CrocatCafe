using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    private static string dirPath = Application.persistentDataPath + "/data";
    public static PlayerData data;

    public static void SetData(PlayerData dt)
    {
        data = dt;
    }
    public static void Save()
    {
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        string json = "";
        json += JsonUtility.ToJson(data, true);
        File.WriteAllText(dirPath + "/data.json" , json);
    }
    
    public static void Load()
    {
        if (!File.Exists(dirPath + "/data.json"))
        {
            Save();
        }
        string json = File.ReadAllText(dirPath + "/data.json");
        PlayerData pdata = ScriptableObject.CreateInstance<PlayerData>();
        JsonUtility.FromJsonOverwrite(json,pdata);
        data = pdata;
    }

}
