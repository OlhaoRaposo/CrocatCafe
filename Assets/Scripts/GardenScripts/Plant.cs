using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]private GameObject[] stages;
    public Timer myTimer;
    private int stage = 0;

    private void Start()
    {
        myTimer = gameObject.GetComponent<Timer>();
    }

    public void Grow()
    {
        foreach (GameObject currentStage in stages) //Oculta tudo
        {
            currentStage.SetActive(false);
        }
        stages[stage].SetActive(true);
        stage++;
    }
}
