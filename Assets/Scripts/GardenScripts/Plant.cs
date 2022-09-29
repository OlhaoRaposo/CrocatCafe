using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]private GameObject[] stages;
    private int stage = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collect();
        }
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

    public void Collect()
    {
        
        GameObject gmbj = GameObject.Find("Armazen");
        gmbj.GetComponent<Armazen>().AdicionaMaterial(3);

    }
    
    
}
