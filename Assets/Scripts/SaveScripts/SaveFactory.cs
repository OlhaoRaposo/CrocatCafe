using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveFactory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> furnitureList;

    [SerializeField] public GameObject progressBar;
    [Header("Plants")] 
    public GameObject[] seeds;
    
    [SerializeField]
    private GameObject[] gridObject;
    [SerializeField]
    GridSystem[] gridManagers;


    
    public void CreateObject(ObjectsData data)
    {
        GameObject a = Instantiate(ReturnListObject(data.objectId), data.position, Quaternion.Euler(data.rotation));
        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(true);
        }
        gridObject = GameObject.FindGameObjectsWithTag("Grid");
        foreach (GameObject grid in gridObject)
        {
            if (grid.name == data.gridCellName) {
                AssignGrid(grid,a);
            }
        }
        if (data.growTimer != 0) {
            if (a.GetComponent<Pot>() != null)
            {
                Pot pot;
                pot = a.GetComponent<Pot>();
                foreach (GameObject seed in seeds) {
                    if (seed.name == data.seedName) {
                        a.GetComponent<Pot>().seed = Instantiate(seed,a.transform.position+new Vector3(0,.25f,0),Quaternion.identity,a.transform);
                    }
                }
                pot.seed.GetComponent<Plant>().progress = data.plantProgress;
                pot.myPlant = a.GetComponent<Pot>().seed.GetComponent<Plant>();
                pot.isOccupied = true;
                pot.myTimer = progressBar;
                GameObject sumonedTimer = Instantiate(progressBar,a.transform.position + new Vector3(0,1,0),Quaternion.identity,a.transform);
                sumonedTimer.SendMessage("StartLoading",pot.seed.GetComponent<Plant>().data.growthTime);
                sumonedTimer.GetComponent<ProgressBar>().progressBar.value = data.growTimer/pot.seed.GetComponent<Plant>().data.growthTime;
                pot.mySeed = pot.seed;
            }
        }
        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(false);
        }
    }

    void AssignGrid(GameObject grid,GameObject furnitureobject)
    {
        furnitureobject.GetComponent<DragableObject>().currentCell = grid.gameObject.GetComponent<GridCell>();
        grid.GetComponent<GridCell>().isOccupied = true;
        grid.GetComponent<GridCell>().currentObject = furnitureobject;
    }

   public void Tggle()
    {
        foreach (GridSystem grid in gridManagers)
        {
            grid.GridToggle(false);
        }
    }
    
    private GameObject ReturnListObject(string id)
    {
        GameObject reference = null;
        foreach (GameObject listObjct in furnitureList)
        {
            if (id == listObjct.GetComponent<ObjectScript>().objectId)
            {
                reference = listObjct;
            }
        }
        return reference;
    }
}

