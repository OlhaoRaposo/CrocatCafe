using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PasserbyScript : MonoBehaviour
{
    private NavMeshAgent navmesh;
    private GameObject endPoint;
    public GameObject pointA;
    public GameObject pointB;
    
    private void Awake()
    {
        navmesh = this.GetComponent<NavMeshAgent>();
        pointA = GameObject.Find("PointA");
        pointB = GameObject.Find("PointB");
    }

    public void Start()
    {
        Walk();
    }

    public void Walk()
    {
        Vector3 add = new Vector3(0, 0, Random.Range(-3,3));
        int index = Random.Range(0, 2);
        if (index == 0)
        {
            transform.position = pointA.transform.position + add;
            navmesh.SetDestination(pointB.transform.position);
        }else {
            transform.position = pointB.transform.position + add;
            navmesh.SetDestination(pointA.transform.position);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }
    }
}
