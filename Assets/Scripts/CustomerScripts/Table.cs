using UnityEngine;
using System.Collections.Generic;

public class Table : MonoBehaviour
{
    public int capacity, maxCapacity;
    public List<NCustomer> customersAllocated;
    private void Start()
    {
        NCustomerManager.instance.allTables.Add(this);
        customersAllocated = new List<NCustomer>();
    }

    private void OnDestroy()
    {
        if (NCustomerManager.instance.allTables != null)
        {
            NCustomerManager.instance.allTables.Remove(this);
            foreach (NCustomer customer in customersAllocated)
            {
                StartCoroutine(customer.Leave());
            }
        }
    }

    public void AllocateCustomerToTable(NCustomer customer)
    {
        capacity++;
        customersAllocated.Add(customer);
    }

    public void RemoveCustomerFromTable(NCustomer customer)
    {
        Debug.Log("Removeu cliente");
        capacity--;
        customersAllocated.Remove(customer);
    }
}
