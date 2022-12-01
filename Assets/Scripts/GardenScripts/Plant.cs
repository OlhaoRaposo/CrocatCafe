using System;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData data;

    [Header("OBJECT STATS")]
    public string myName;
    [SerializeField] private string loot;
    public int plantCode;
    public int plantValue;
    [SerializeField] private GameObject[] stages;
    [SerializeField] private float growthTime;
    public bool isReady;

    private int stage = 0;
    private float progress, stageChangeTreshHold = 0.33f;

    private void Start()
    {
        myName = data.myName;
        growthTime = data.growthTime;
        plantCode = data.plantCode;

        int aux = 0;
        stages = new GameObject[data.stages.Length];
        foreach (GameObject stage in data.stages)
        {
            stages[aux] = Instantiate(data.stages[aux], transform.position, transform.rotation);
            stages[aux].transform.SetParent(gameObject.transform);
            aux++;
        }

        loot = data.loot;
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
            progress += 1 / growthTime;
            if (progress >= stageChangeTreshHold)
            {
                stageChangeTreshHold += 0.33f;
                ChangeStage();
            }
            Invoke("Grow", 1.0f);
        }
        else
        {
            if (TutorialController.instance.tutorialProgress < 4)
            {
                TutorialController.instance.AdvanceTutorial();
                TutorialController.instance.OpenTutorialWindow();
            }
            isReady = true;
            return;
        }
    }
}
