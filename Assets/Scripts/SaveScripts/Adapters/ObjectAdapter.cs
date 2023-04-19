using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAdapter : ObjectsData
{
    public ObjectAdapter(ObjectScript furniture)
    {
        position = furniture.transform.position;
        rotation = furniture.transform.rotation.eulerAngles;
        objectId = furniture.objectId;
        gridCellName = furniture.GetComponent<DragableObject>().currentCell.name;
    }
}
