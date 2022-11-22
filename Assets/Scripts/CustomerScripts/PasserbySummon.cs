using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PasserbySummon : MonoBehaviour
{
    public GameObject passerby;
    void Start()
    {
        StartCoroutine(SummonPaserby());
    }

    IEnumerator SummonPaserby()
    {
        yield return new WaitForSeconds(1);
        Instantiate(passerby,transform.position,quaternion.identity);
        StartCoroutine(SummonPaserby());
    }
}
