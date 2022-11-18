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
        CustomerScript.instance.maxCustomersAmmount += 2;
    }
    
    public void DeleteTable()
    {
        tablesAmmount--;
        CustomerScript.instance.maxCustomersAmmount -= 2;
        if(CustomerScript.instance.customersAmmount > CustomerScript.instance.maxCustomersAmmount)
        {
            CustomerScript.instance.DeleteCustomer();
            CustomerScript.instance.DeleteCustomer();
            CustomerScript.instance.RemoveRequest();
            CustomerScript.instance.RemoveRequest();
        }
    }
}
