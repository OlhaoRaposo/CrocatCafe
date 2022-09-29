using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript :  IObjectID
{
    [Header("OBJECT IDENTIFTY")] 
    public bool isOven;
    private void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
    }

    public void ObjectInteract()
    {
        if (isOven)
        {
            GameObject gmbj;
            gmbj = GameObject.Find("OvenManager");
            gmbj.GetComponent<OvenScript>().OpenUi();
        }
    }
}
