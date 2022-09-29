using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            test.GetComponent<Armazen>().AdicionaMaterial(1);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            test.GetComponent<Armazen>().RemoveMaterial(1);
        }
    }
}
