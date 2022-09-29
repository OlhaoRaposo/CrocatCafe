using UnityEngine;

public class SpawnOnCommand : MonoBehaviour
{
    [SerializeField]private KeyCode trigger;
    [SerializeField]private GameObject item;
    [SerializeField]private Vector3 SpawnPoint;

    private void Update()
    {
        if(Input.GetKeyDown(trigger))
        {
            Instantiate(item, SpawnPoint, transform.rotation);
        }
    }
}
