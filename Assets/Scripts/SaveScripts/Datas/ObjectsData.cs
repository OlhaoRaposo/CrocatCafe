using UnityEngine;
using System;
[Serializable]
public class ObjectsData
{
    [Header("Object")]
    public Vector3 position;
    public Vector3 rotation;
    [Header("Object Scripts")]
    public string objectId;
    [Header("Dragable Object")]
    public string gridCellName;
}