using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    public DestinationList destinationList = new DestinationList();
    public GameObject chillPlace;
    public NavMeshAgent navMesh;
    private bool isDoingTask = false;

    public void Start()
    {
        destinationList.InitList();
    }

    public void AddDestination(GameObject destinationObject, int waitTime)
    {
        destinationList.AddDestination(destinationObject, waitTime);
        if(isDoingTask == false)
        {
            StartCoroutine(DestinationCheck(waitTime));
        }
    }

    public void CycleDestination()
    {
        isDoingTask = false;
        destinationList.RemoveDestination();
        if(destinationList.head.nextDestination != null)
        {
            StartCoroutine(DestinationCheck(destinationList.head.nextDestination.waitTime));
        }
        else
        {
            navMesh.destination = chillPlace.transform.position;
        }
    }

    IEnumerator DestinationCheck(int waitTime)
    {
        isDoingTask = true;
        yield return new WaitForSeconds(1);
        if(Vector3.Distance(transform.position, destinationList.head.nextDestination.destinationObject.transform.position) <= 1)
        {
            yield return new WaitForSeconds(waitTime);
            CycleDestination();
        }
        else
        {
            navMesh.destination = destinationList.head.nextDestination.destinationObject.transform.position;
            StartCoroutine(DestinationCheck(waitTime));
        }
    }
}
