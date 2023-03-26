using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public PlantData data;

    [Header("OBJECT STATS")]
    [SerializeField] private GameObject[] stages;
    public bool isReady;

    private int stage = 0;
    private float progress, stageChangeTreshHold = 0.33f;

    private void Start()
    {
        int aux = 0;
        stages = new GameObject[data.stages.Length];
        foreach (GameObject stage in data.stages)
        {
            stages[aux] = Instantiate(data.stages[aux], transform.position, transform.rotation);
            stages[aux].transform.SetParent(gameObject.transform);
            aux++;
        }
        Invoke("Grow", 0);
    }

    public void ChangeStage()
    {
        foreach (GameObject currentStage in stages) //Oculta tudo
        {
            currentStage.SetActive(false);
        }
        stages[stage].SetActive(true);
        stage++;
    }

    private void Grow()
    {
        if (progress < 1.0f)
        {
            progress += 1 / data.growthTime;
            if (progress >= stageChangeTreshHold)
            {
                stageChangeTreshHold += 0.33f;
                ChangeStage();
            }
            Invoke("Grow", 1.0f);
        }
        else
        {
            isReady = true;
            return;
        }
    }
}
