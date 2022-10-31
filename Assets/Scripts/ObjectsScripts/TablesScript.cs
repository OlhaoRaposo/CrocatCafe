using UnityEngine;

public class TablesScript : MonoBehaviour
{
    public int tablesAmmount;
    public static TablesScript instance;
    void Start()
    {
        instance = this;
    }

    public void AddTable()
    {
        tablesAmmount++;
        CustomerSpawner.instance.maxCustomersAmmount += 2;
    }
    
    public void DeleteTable()
    {
        tablesAmmount--;
        CustomerSpawner.instance.maxCustomersAmmount -= 2;
        if(CustomerSpawner.instance.customersAmmount > CustomerSpawner.instance.maxCustomersAmmount)
        {
            CustomerSpawner.instance.DeleteCustomer();
            CustomerSpawner.instance.DeleteCustomer();
        }
    }
}
