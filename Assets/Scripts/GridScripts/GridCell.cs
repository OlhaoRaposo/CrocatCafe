using UnityEngine;

public class GridCell : MonoBehaviour
{
    public string id;
    public Vector2 tilePos;
    public int rotationValue = 0;
    public bool isOccupied = false;
    public GameObject currentObject;
}
