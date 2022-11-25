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
    private int[] PossibleOrders;
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
        patience = Random.Range(20,30);
    }
    

    private void ChooseOrder()
    {
        //Escolhe O pedido
        currentOrder = PossibleOrders[Random.Range(0, PossibleOrders.Length - 1)];
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
        }else
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
            Debug.Log("Chegay");
            //Chegou ao exibitor
            switch (currentOrder)
            {
                case 0:
                    if (armazen.GetComponent<Armazen>().breads > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemovePao(1);
                        StartCoroutine(GoToExit(5));
                        Debug.Log("serve");
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }
                    break;
                case 1:
                    if (armazen.GetComponent<Armazen>().cafeAtual > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemoveCafé(1);
                        StartCoroutine(GoToExit(5));                    
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }
                    break;
                case 2:
                    if (armazen.GetComponent<Armazen>().sucosAtual > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemoveSucos(1);
                        StartCoroutine(GoToExit(5));                    
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }
                    break;
                case 3:
                    if (armazen.GetComponent<Armazen>().coxinhaAtual > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemoveCoxinha(1);
                        StartCoroutine(GoToExit(5));                    
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }             
                    break;
                case 4:
                    if (armazen.GetComponent<Armazen>().boloAtual > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemoveBolos(1);
                        StartCoroutine(GoToExit(5));                    
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }
                    break;
                case 5:
                    if (armazen.GetComponent<Armazen>().paoDeQueijoAtual > 0)
                    {
                        Serve();
                        armazen.GetComponent<Armazen>().RemovePaoDeQueijo(1);
                        StartCoroutine(GoToExit(5));                    
                    }else {
                        if (hasAskedOrder != true) {
                            AskOrder();
                            AngryExit();
                        }
                        Debug.Log("Nao tem");
                    }
                    break;
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
        navMesh.SetDestination(exit[Random.Range(0,exit.Length)].transform.position);
        orderSpawn.GetComponent<OrderSpawner>().RemovePlate(order);
    }
    private void AskOrder()
    {
        hasAskedOrder = true;
        orderSpawn.GetComponent<OrderSpawner>().AddPlate(currentOrder,this.gameObject);
    }
    public void Serve()
    {
       orderSpawn.GetComponent<OrderSpawner>().RemovePlate(order);
    }

    private void OnDestroy()
    {
    }
}
