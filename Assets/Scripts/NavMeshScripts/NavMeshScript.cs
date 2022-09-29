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
    public int bakeTime;

  

    void Update()
    {
        //Substituir por um Getcomponent no gatinho com o bakeDestin e o objeto onde ele vai andar
        if (Input.GetKey(KeyCode.E)) {
            BakeDestin(destino);
        }
    }
    public void BakeDestin(GameObject obj)
    {
        navMesh.destination = obj.transform.position;
        StartCoroutine(CheckDestination(obj));
    }

    IEnumerator AfterBakeDestin()
    {
        yield return new WaitForSeconds(bakeTime);
        navMesh.destination = chillPlace.transform.position;
    }

    IEnumerator CheckDestination(GameObject obj)
    {
        yield return new WaitForSeconds(1);
        if (transform.position.magnitude - obj.transform.position.magnitude >= -.3f)
        {
            StartCoroutine(AfterBakeDestin());
            StopCoroutine(CheckDestination(obj));
        }
        else
            StartCoroutine(CheckDestination(obj));
        Debug.Log(transform.position.magnitude - obj.transform.position.magnitude);
        Debug.Log("Check");
    }
}
