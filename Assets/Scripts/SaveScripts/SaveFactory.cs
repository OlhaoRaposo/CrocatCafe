using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveFactory : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> furnitureList;

    private GameObject[] gridObject;

    private void Start()
    {
        Debug.Log(furnitureList);
    }

    public void CreateObject(ObjectsData data)
    {
        gridObject = GameObject.FindGameObjectsWithTag("Grid");
        GameObject a = Instantiate(ReturnListObject(data.objectId), data.position, Quaternion.Euler(data.rotation));
        foreach (GameObject grid in gridObject)
        {
            if (grid.name == data.gridCellName)
            {
                Debug.Log("Achei");
                a.GetComponent<DragableObject>().currentCell = grid.GetComponent<GridCell>();
                grid.GetComponent<GridCell>().currentObject = a;
            }
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

