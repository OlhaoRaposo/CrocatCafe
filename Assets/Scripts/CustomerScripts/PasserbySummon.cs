using UnityEngine;
using System.Collections;

public class PasserbySummon : MonoBehaviour
{
    public GameObject passerby, customer;
    GameObject manager;

    void Start()
    {
        StartCoroutine(SummonPaserby());
    }
    IEnumerator SummonPaserby()
    {
        yield return new WaitForSeconds(1);

        int randomizer = Random.Range(1, 11);
        if(randomizer > 1)
        {
            Instantiate(passerby, transform.position, Quaternion.identity);
        }
        else
        {
            if(NCustomerManager.instance.allShowCases.Count != 0 && NCustomerManager.instance.allTables.Count != 0 && NCustomerManager.instance.allCustomers.Count < NCustomerManager.instance.allTables.Count * 2)
            {
                Instantiate(customer, transform.position, Quaternion.identity);
            }
        }
        StartCoroutine(SummonPaserby());
    }
}
