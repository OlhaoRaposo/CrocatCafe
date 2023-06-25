using UnityEngine;
using System.Collections;

public class PasserbySummon : MonoBehaviour
{
    public GameObject[] passerby, customer;
    //GameObject manager;
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;

    void Start()
    {
        StartCoroutine(SummonPaserby());
    }
    IEnumerator SummonPaserby()
    {
        yield return new WaitForSeconds(Random.Range(1,4));

        int randomizer = Random.Range(1, 11);
        if(randomizer > 1)
        {
            int rng = Random.Range(0, passerby.Length);
            GameObject passerbyIn =  Instantiate(passerby[rng], transform.position, Quaternion.identity);
            Walk(passerbyIn);
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
    public void Walk(GameObject passerby)
    {
        Vector3 add = new Vector3(Random.Range(-4, 4), 0,0 );
        int index = Random.Range(0, 7);

        switch (index)
        {
            case 0:
                passerby.transform.position = pointA.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointB.transform);
                break;
            case 1:
                passerby.transform.position = pointB.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointA.transform);
                break;
            case 2:
                passerby.transform.position = pointC.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointA.transform);
                break;
            case 3:
                passerby.transform.position = pointD.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointA.transform);
                break;
            case 4:
                passerby.transform.position = pointA.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointD.transform);
                break;
            case 5:
                passerby.transform.position = pointA.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointC.transform);
                break;
            case 6:
                passerby.transform.position = pointC.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointD.transform);
                break;
            case 7:
                passerby.transform.position = pointD.transform.position + add;
                passerby.GetComponent<PasserbyScript>().Walk(pointC.transform);
                break;
        }
       
    }
}
