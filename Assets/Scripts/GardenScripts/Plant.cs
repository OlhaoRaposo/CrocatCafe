using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField]private GameObject[] stages;
    private int stage = 0;

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
