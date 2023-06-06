using UnityEngine;
using System.Collections.Generic;

public class NCustomerManager : MonoBehaviour
{
    public static NCustomerManager instance;
    public List<NCustomer> allCustomers;
    public List<Table> allTables;
    public List<GameObject> allShowCases;

    private void Awake()
    {
        instance = this;
        allCustomers = new List<NCustomer>();
        allShowCases = new List<GameObject>();
        allTables = new List<Table>();
    }

    public void CloseBakery()
    {
        foreach (NCustomer customer in allCustomers)
        {
            NOrderManager.instance.RemoveOrder(customer.myOrder);
            StartCoroutine(customer.Leave());
        }
    }
}
