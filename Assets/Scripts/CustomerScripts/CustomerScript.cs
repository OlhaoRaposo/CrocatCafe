using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    public int customersAmmount, maxCustomersAmmount;
    public GameObject[] customers;
    public Text menuText;
    public string[] orders;
    [SerializeField]private GameObject clientFrame;
    [SerializeField]private float spawnRate;
    public static CustomerScript instance;
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
        GameObject[] temp = customers;
        customers = new GameObject[temp.Length + 1];
        for (int i = 0; i < temp.Length; i++)
        {
            customers[i] = temp[i];
        }
        customers[customers.Length - 1] = Instantiate(clientFrame, transform.position, transform.rotation);
    }

    public void DeleteCustomer()
    {
        if(customersAmmount > 0)
        {
            customersAmmount--;
            Destroy(customers[customers.Length - 1]);
            GameObject[] temp = customers;
            customers = new GameObject[temp.Length - 1];
            for (int i = 0; i < customers.Length; i++)
            {
                customers[i] = temp[i];
            }
        }
    }

    public void AddRequest(string request)
    {
        string[] temp = orders;
        orders = new string[temp.Length + 1];
        for (int i = 0; i < temp.Length; i++)
        {
            orders[i] = temp[i];
        }
        orders[orders.Length - 1] = $"\n{request}";
        menuText.text = ""; 
        for (int i = 0; i < orders.Length; i++)
        {
            menuText.text += orders[i];
        }
    }

    public void RemoveRequest()
    {
        string[] temp = orders;
        orders = new string[temp.Length - 1];
        menuText.text = ""; 
        for (int i = 0; i < orders.Length; i++)
        {
            orders[i] = temp[i];
            menuText.text += orders[i];
        }
    }

    public void FullfillRequest()
    {
        RemoveRequest();
        DeleteCustomer();
    }
}
