using System;
using UnityEngine;
using System.IO;

class SceneData
{
    public ObjectsData[] furniterObjects;
    public ArmazenData armazenData;
    public TimeData time;

}
public class SaveGame : MonoBehaviour
{ 
    private  string dirPath;
    [SerializeField]
    private SaveFactory SaveFactory;
    [SerializeField]
    private TimeControler timeControler;
    private void Awake() {
        dirPath = Application.dataPath + "/save.txt";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L)) {
            Load();
        }
    }

    private void Save()
    {
        SceneData data = new SceneData();
        ObjectScript[] furnitures = FindObjectsOfType<ObjectScript>();
        data.furniterObjects = new ObjectsData[furnitures.Length];
        for (int i = 0; i < furnitures.Length; i++)
        {
            data.furniterObjects[i] = new ObjectAdapter(furnitures[i]);
        }
        data.armazenData = new ArmazenAdapter(ArmazenManager.instance.GetComponent<ArmazenManager>());
        data.time = new TimeAdapter(timeControler);
        string s = JsonUtility.ToJson(data,true);
        Debug.Log(s);
        File.WriteAllText(dirPath,s);
    }

    private void Load()
    {
        GridSystem[] gridManagers = FindObjectsOfType<GridSystem>();
        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(true);
        }
        
        ObjectScript[] objects = FindObjectsOfType<ObjectScript>();
        foreach (ObjectScript furniture in objects)
        {
            Destroy(furniture.gameObject);
        }
        string s = File.ReadAllText(dirPath);
        SceneData data = JsonUtility.FromJson<SceneData>(s);
        
        ArmazenManager.instance.money = data.armazenData.moneydata;
        Debug.Log(data.armazenData.moneydata);
        
        for (int i = 0; i < data.furniterObjects.Length; i++)
        {
            SaveFactory.CreateObject(data.furniterObjects[i]);
        }


        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(false);
        }
    }
}
