using UnityEngine;

public class Table : MonoBehaviour
{
    public int capacity;
    private void Start()
    {
        TablesScript.instance.AddTable();
    }

    private void OnDestroy()
    {
        TablesScript.instance.DeleteTable();
    }
}
