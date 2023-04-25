using System;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

class SceneData
{
    public ObjectsData[] furniterObjects;
    public TimeData time;
    public ArmazenData armazenData;
}
public class SaveGame : MonoBehaviour
{
    private string dirPath;
    [SerializeField]
    private SaveFactory SaveFactory;
    [SerializeField]
    private TimeControler timeControler;
    public static SaveGame instance;
    private void Awake()
    {
        instance = this;
        dirPath = Application.dataPath + "/save.txt";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < ArmazenManager.instance.ingredientAmmount.Length; i++)
            {
                ArmazenManager.instance.ingredientAmmount[i] = Random.Range(0, 10);
            }
            for (int i = 0; i < ArmazenManager.instance.foodAmmount.Length; i++)
            {
                ArmazenManager.instance.foodAmmount[i] = Random.Range(0, 10);
            }
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }
        }
    }

    public void Save()
    {
        SceneData data = new SceneData();
        ObjectScript[] furnitures = FindObjectsOfType<ObjectScript>();
        data.furniterObjects = new ObjectsData[furnitures.Length];
        for (int i = 0; i < furnitures.Length; i++)
        {
            data.furniterObjects[i] = new ObjectAdapter(furnitures[i]);
        }
        data.time = new TimeAdapter(timeControler);
        data.armazenData = new ArmazenAdapter(ArmazenManager.instance.GetComponent<ArmazenManager>());

        string s = JsonUtility.ToJson(data, true);
        Debug.Log(s);
        File.WriteAllText(dirPath, s);
    }

    public void Load()
    {
        if (File.Exists(dirPath))
        {
            GridSystem[] gridManagers = FindObjectsOfType<GridSystem>();
            ToggleGrid(gridManagers, true);
            CleanScene();

            string s = File.ReadAllText(dirPath);
            SceneData data = JsonUtility.FromJson<SceneData>(s);

            AttachArmazenVar(data.armazenData);
            timeControler.currentTime = DateTime.Now.Date + TimeSpan.FromHours(data.time.hour) + TimeSpan.FromMinutes(data.time.min);

            for (int i = 0; i < data.furniterObjects.Length; i++)
            {
                SaveFactory.CreateObject(data.furniterObjects[i]);
            }
            ToggleGrid(gridManagers, false);
        }
    }

    private void AttachArmazenVar(ArmazenData data)
    {
        ArmazenManager.instance.SetMoney(data.moneydata);
        for (int i = 0; i < data.ingredientAmmount.Length; i++)
        {
            ArmazenManager.instance.ingredientAmmount[i] = data.ingredientAmmount[i];
        }
        for (int i = 0; i < data.foodAmmount.Length; i++)
        {
            ArmazenManager.instance.foodAmmount[i] = data.foodAmmount[i];
        }

    }

    private void CleanScene()
    {
        ObjectScript[] objects = FindObjectsOfType<ObjectScript>();
        foreach (ObjectScript furniture in objects)
        {
            Destroy(furniture.gameObject);
        }
    }
    private void ToggleGrid(GridSystem[] gridManagers, bool toggle)
    {
        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(toggle);
        }
    }
}
