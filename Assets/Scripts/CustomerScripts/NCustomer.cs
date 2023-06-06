using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NCustomer : MonoBehaviour
{
    [SerializeField] private NavMeshAgent myAgent;
    [SerializeField] private GameObject myTimer;
    [HideInInspector] public FoodData myOrder;
    private Table myTable;
    private bool isGoingToRestaurant = true;


    private void Start()
    {
        NCustomerManager.instance.allCustomers.Add(this);
        myOrder = ArmazenManager.instance.GetAllFoods()[Random.Range(0, ArmazenManager.instance.GetAllFoods().Length)];

        SetDestinationToShowCase();
    }

    private void SetDestinationToShowCase()
    {
        if (NCustomerManager.instance.allShowCases.Count != 0)
        {
            int aux = Random.Range(0, NCustomerManager.instance.allShowCases.Count);
            myAgent.SetDestination(NCustomerManager.instance.allShowCases[aux].transform.position);
            if (isGoingToRestaurant == true)
            {
                isGoingToRestaurant = false;
                StartCoroutine(RestaurantLoop());
            }
            return;
        }

        StartCoroutine(Leave());
    }

    private void SetDestinationToTable()
    {
        foreach (Table table in NCustomerManager.instance.allTables)
        {
            if (table.capacity < table.maxCapacity)
            {
                myTable = table;
                table.AllocateCustomerToTable(this);
                myAgent.SetDestination(table.gameObject.transform.position);
                return;
            }
        }

        StartCoroutine(Leave());
    }

    private IEnumerator RestaurantLoop()
    {
        int randomTimeWait, randomGain;

        while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
        {
            yield return new WaitForSeconds(1);
        }

        randomTimeWait = Random.Range(5, 11);
        yield return new WaitForSeconds(randomTimeWait);

        NOrderManager.instance.AddOrder(myOrder);
        Debug.Log("Pediu");

        SetDestinationToTable();
        while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
        {
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Chegou na mesa");
        if (ArmazenManager.instance.FoodAmmount(myOrder.foodName) > 0)
        {
            NOrderManager.instance.RemoveOrder(myOrder);
            ArmazenManager.instance.RemoveFood(myOrder.foodName, 1);
            Debug.Log("Comendo...");

            randomTimeWait = Random.Range(10, 21);
            yield return new WaitForSeconds(randomTimeWait);

            SetDestinationToShowCase();
            while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
            {
                yield return new WaitForSeconds(1);
            }

            randomGain = Random.Range(1, 11);
            ArmazenManager.instance.money += myOrder.foodPrice + randomGain;
            ArmazenManager.instance.UpdateMoneyText();
            Debug.Log("Pagou");
        }
        else
        {
            float patience = Random.Range(1, 11);
            float waitTime, aux = 0;
            if (patience < 3)
            {
                waitTime = 20;
            }
            else
            {
                waitTime = 10 * patience;
            }

            myTimer.SetActive(true);
            myTimer.GetComponent<ProgressBar>().StartLoading(waitTime);
            Debug.Log("Esperando " + waitTime);

            while (aux <= waitTime)
            {
                aux++;
                if (ArmazenManager.instance.FoodAmmount(myOrder.foodName) > 0)
                {
                    NOrderManager.instance.RemoveOrder(myOrder);
                    ArmazenManager.instance.RemoveFood(myOrder.foodName, 1);
                    myTimer.SetActive(false);

                    Vector3 myTablePos = myAgent.destination;

                    Debug.Log("Buscando comida");
                    SetDestinationToShowCase();
                    while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
                    {
                        yield return new WaitForSeconds(1);
                    }
                    Debug.Log("Voltando pra mesa");

                    myAgent.SetDestination(myTablePos);
                    while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
                    {
                        yield return new WaitForSeconds(1);
                    }
                    Debug.Log("Comendo");

                    randomTimeWait = Random.Range(10, 21);
                    yield return new WaitForSeconds(randomTimeWait);

                    SetDestinationToShowCase();
                    while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
                    {
                        yield return new WaitForSeconds(1);
                    }
                    Debug.Log("Pagou");

                    ArmazenManager.instance.money += myOrder.foodPrice;
                    ArmazenManager.instance.UpdateMoneyText();

                    break;
                }
                yield return new WaitForSeconds(1);
            }
        }

        StartCoroutine(Leave());
    }

    public IEnumerator Leave()
    {
        StopCoroutine(RestaurantLoop());

        NCustomerManager.instance.allCustomers.Remove(this);
        NOrderManager.instance.RemoveOrder(myOrder);
        if (myTable != null)
        {
            myTable.RemoveCustomerFromTable(this);
        }

        GameObject[] exits;
        exits = GameObject.FindGameObjectsWithTag("Exit");
        myAgent.SetDestination(exits[Random.Range(0, exits.Length)].transform.position);

        while (Vector3.Distance(transform.position, myAgent.destination) > 1.25f)
        {
            yield return new WaitForSeconds(1);
        }

        Debug.Log("Morri");
        Destroy(gameObject);

    }
}
