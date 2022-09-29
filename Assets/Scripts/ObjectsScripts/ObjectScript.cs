using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript :  IObjectID
{
    [Header("OBJECT STATS")]
    public GameObject armazen;

    public virtual void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
    }

    public virtual void OpenUi() { }
    
}
