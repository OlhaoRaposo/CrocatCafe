using UnityEngine;
using System;
[Serializable]
public class ObjectsData
{
    [Header("Object Scripts")]
    public string objectId;
    [Header("Dragable Object")]
    public Vector3 position;
    public Vector3 rotation;
    public string gridCellName;
    public Vector2 objectSize;
    [Header("Bench")]
    public ScriptableObject[] acceptedRecipes;
    public string managerName;
}
