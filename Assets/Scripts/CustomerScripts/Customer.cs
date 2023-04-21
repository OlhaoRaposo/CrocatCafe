using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Customer : MonoBehaviour
{
    [SerializeField]
    private int currentOrder;
    [SerializeField]
    private int patience;
    [SerializeField]
    private FoodData[] PossibleOrders;
    [SerializeField]
    private bool hasAskedOrder = false;
    private NavMeshAgent navMesh;
    public GameObject order;
    public GameObject orderSpawn;
    public GameObject[] showCase;
    public GameObject armazen;


    private void Awake()
    {
        orderSpawn = GameObject.Find("OrderSpawn");
        navMesh = this.gameObject.GetComponent<NavMeshAgent>();

    }

    void Start()
    {
        ChooseOrder();
        //patience = Random.Range(35, 60);
        patience = Random.Range(20, 30);
    }


    private void ChooseOrder()
    {
        //Escolhe O pedido
        currentOrder = Random.Range(0, PossibleOrders.Length - 1);
        //Chama o void para ir em direção ao exibitor
        SetDestinationToExhibitor();
    }
    private void SetDestinationToExhibitor()
    {
        //Leva o Cliente ate o exibitor

        showCase = GameObject.FindGameObjectsWithTag("ShowCase");
        int showCaseIndex = Random.Range(0, showCase.Length);
        if (showCase.Length != 0)
        {
            navMesh.SetDestination(showCase[showCaseIndex].transform.position);
            StartCoroutine(CheckDistanceToShowCase(showCase[showCaseIndex]));
        }
        else
            Destroy(gameObject);
    }
    IEnumerator CheckDistanceToShowCase(GameObject showCase)
    {
        //Checa caso o cliente chege ao exibitor
        yield return new WaitForSeconds(1);
        Vector3 distance;
        distance = transform.position - showCase.transform.position;
        //Debug.Log("Distance to ShowCase" + distance.magnitude);
        if (distance.magnitude <= 1.6f)
        {
            armazen = GameObject.Find("ArmazenManager");
            //Chegou ao exibitor
            if (ArmazenManager.instance.FoodAmmount(PossibleOrders[currentOrder].foodName) > 0)
            {
                Serve();
                ArmazenManager.instance.RemoveFood(PossibleOrders[currentOrder].foodName, 1);
                StartCoroutine(GoToExit(5));
            }
            else
            {
                if (hasAskedOrder != true)
                {
                    AskOrder();
                    AngryExit();
                }
            }
        }
        StartCoroutine(CheckDistanceToShowCase(showCase));
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Exit") == true)
        {
            GameObject.Find("CustomerManager").GetComponent<CustomerScript>().customersAmmount -= 1;
            Destroy(gameObject);
        }
    }
    private void AngryExit()
    {
        StartCoroutine(GoToExit(patience));
    }

    IEnumerator GoToExit(int timer)
    {
        yield return new WaitForSeconds(timer);
        GameObject[] exit;
        exit = GameObject.FindGameObjectsWithTag("Exit");
        navMesh.SetDestination(exit[Random.Range(0, exit.Length)].transform.position);
        orderSpawn.GetComponent<OrderSpawner>().RemovePlate(order);
    }
    private void AskOrder()
    {
        hasAskedOrder = true;
        orderSpawn.GetComponent<OrderSpawner>().AddPlate(PossibleOrders[currentOrder], this.gameObject);
    }
    public void Serve()
    {
        orderSpawn.GetComponent<OrderSpawner>().RemovePlate(order);
    }

    private void OnDestroy()
    {
    }
}
