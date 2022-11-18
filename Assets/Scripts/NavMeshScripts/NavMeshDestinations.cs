using UnityEngine;

public class Destination
{
    public int waitTime;
    public GameObject destinationObject;
    public Destination nextDestination, previousDestination;

    public Destination(int waitTime, GameObject destinationObject, Destination nextDestination)
    {
        this.waitTime = waitTime;
        this.destinationObject = destinationObject;
        this.nextDestination = nextDestination;
    }
}

public class DestinationList
{
    public Destination head, tail;
    public void InitList()
    {
        head = new Destination(-1, null, null);
        tail = head;
    }

    public void AddDestination(GameObject destinationObject, int waitTime)
    {
        Destination n = new Destination(waitTime, destinationObject, null);
        tail.nextDestination = n;
        n.previousDestination = tail;
        tail = n;
    }

    public void RemoveDestination()
    {
        Destination deletedDestination = head.nextDestination;
        if(head.nextDestination.nextDestination != null)
        {
            head.nextDestination = head.nextDestination.nextDestination;
            head.nextDestination.previousDestination = head;
        }
        else
        {
            head.nextDestination = null;
            tail = head;
        }
        deletedDestination = null;
    }
}
