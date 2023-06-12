using UnityEngine;
using System.Collections;

public class PasserbySummon : MonoBehaviour
{
    public GameObject[] passerby, customer;
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
            int rng = Random.Range(0, passerby.Length);
            Instantiate(passerby[rng], transform.position, Quaternion.identity);
        }
        else
        {
            if(NCustomerManager.instance.allShowCases.Count != 0 && NCustomerManager.instance.allTables.Count != 0 && NCustomerManager.instance.allCustomers.Count < NCustomerManager.instance.allTables.Count * 2)
            {
                int rng = Random.Range(0, customer.Length);
                Instantiate(customer[rng], transform.position, Quaternion.identity);
            }
        }
        StartCoroutine(SummonPaserby());
    }
}
