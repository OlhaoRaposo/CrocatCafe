using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    public int customersAmmount, maxCustomersAmmount;
    public Customer[] customers;
    [SerializeField]private float spawnRate;
    public static CustomerSpawner instance;
    private void Start()
    {
        instance = this;
        InvokeRepeating("SummonCustomer", 10.0f, spawnRate);
    }

    private void SummonCustomer()
    {
        if(customersAmmount < maxCustomersAmmount)
        {
            AddCustomer();
        }
    }

    public void AddCustomer()
    {
        customersAmmount++;
        Customer[] temp = customers;
        customers = new Customer[temp.Length + 1];
        for (int i = 0; i < temp.Length; i++)
        {
            customers[i] = temp[i];
        }
        //INSTANCIAR CLIENTE
    }

    public void DeleteCustomer()
    {
        if(customersAmmount > 0)
        {
            customersAmmount--;
            Customer[] temp = customers;
            customers = new Customer[temp.Length - 1];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = temp[i];
            }
        }
    }
}
