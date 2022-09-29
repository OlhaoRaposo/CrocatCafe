using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshScript : MonoBehaviour
{
    public GameObject destino;
    public GameObject chillPlace;
    public NavMeshAgent navMesh;
    public void BakeDestin(GameObject obj,int baketime)
    {
        navMesh.destination = obj.transform.position;
        StartCoroutine(CheckDestination(obj,baketime));
    }

    IEnumerator AfterBakeDestin(int baketime)
    {
        yield return new WaitForSeconds(baketime);
        navMesh.destination = chillPlace.transform.position;
    }

    IEnumerator CheckDestination(GameObject obj,int baketime)
    {
        yield return new WaitForSeconds(1);
        if (transform.position.magnitude - obj.transform.position.magnitude >= -.3f)
        {
            StartCoroutine(AfterBakeDestin(baketime));
            StopCoroutine(CheckDestination(obj,baketime));
        }
        else
            StartCoroutine(CheckDestination(obj,baketime));
    }
}
