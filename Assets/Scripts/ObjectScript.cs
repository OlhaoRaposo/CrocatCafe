using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript :  IObjectID
{
    void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
    }

    void Update()
    {
        
    }
}
