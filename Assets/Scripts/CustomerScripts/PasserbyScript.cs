using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class PasserbyScript : MonoBehaviour
{
    private NavMeshAgent navmesh;
    private void Awake()
    {
        navmesh = this.GetComponent<NavMeshAgent>();
    }
    
    public void Walk(Transform point)
    {
        navmesh.SetDestination(point.transform.position);
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Exit"))
        {
            Destroy(gameObject);
        }
    }
}
