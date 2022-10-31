using UnityEngine;

public class Table : MonoBehaviour
{
    
    private void Start()
    {
        TablesScript.instance.AddTable();
    }

    private void OnDestroy()
    {
        TablesScript.instance.DeleteTable();
    }
}
