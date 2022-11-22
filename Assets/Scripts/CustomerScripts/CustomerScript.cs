using UnityEngine;
using UnityEngine.UI;

public class CustomerScript : MonoBehaviour
{
    [SerializeField]private GameObject clientFrame;
    [SerializeField]private float spawnRate;
    public int customersAmmount, maxCustomersAmmount;
    public GameObject[] customers;
    public GameObject pointA;
    public GameObject pointB;
    public Text menuText;
    public string[] orders;
    
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

        Vector3 add = new Vector3(0, 0, Random.Range(-3,3));
        int index = Random.Range(0, 2);
        if (index == 0)
        {
            customers[customers.Length - 1] = Instantiate(clientFrame, pointA.transform.position + add, transform.rotation);
        }else
            customers[customers.Length - 1] = Instantiate(clientFrame, pointB.transform.position + add, transform.rotation);


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
