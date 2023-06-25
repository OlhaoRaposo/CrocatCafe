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
        //Caso seja um pote
        if (furniture.GetComponent<Pot>() != null) {
            if (furniture.GetComponent<Pot>().seed != null)
            {
                growTimer = furniture.GetComponent<Pot>().myTimer.GetComponent<ProgressBar>().loadTime;
                seedName = furniture.GetComponent<Pot>().seed.name;
                if (furniture.GetComponent<Plant>() != null)
                {
                    plantProgress = furniture.GetComponent<Plant>().progress;
                }
            }
        }
    }
}
