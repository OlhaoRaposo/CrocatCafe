using UnityEngine;
using UnityEngine.UI;

public class GardenScript : MonoBehaviour
{
    public GameObject[] plants;
    public int[] availableAmmount;
    [SerializeField] private GameObject currentPot;


    [SerializeField] private GameObject myPanel;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Text[] seedsAmmountText;
    public static GardenScript instance;
    private void Start()
    {
        availableAmmount = new int[plants.Length];
        for (int i = 0; i < availableAmmount.Length; i++)
        {
            availableAmmount[i] = 1;
            SetSeedText(i);
        }
        instance = this;
        //carregar sementes do inventário
    }

    public void OpenUi(GameObject pot)
    {
        currentPot = pot;

        myPanel.SetActive(true);
    }

    public void SetDestinationToPot(GameObject clickedPot, int timeSpent)
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(clickedPot, timeSpent);
    }

    public void SummonPlant(int plant)
    {
        if (availableAmmount[plant] > 0)
        {
            Pot potCode = currentPot.GetComponent<Pot>();
            potCode.seed = plants[plant];
            potCode.InteractWithSeed();

            availableAmmount[plant]--;
            SetSeedText(plant);

            AudioBoard.instance.PlayAudio("SFX_UI_Shop");
        }
        else
        {
            AudioBoard.instance.PlayAudio("SFX_UI_Exit");
        }
        myPanel.SetActive(false);
        EditMode.instance.ToggleCanvas(false);
    }

    public void SetSeedText(int index)
    {
        seedsAmmountText[index].text = $"x{availableAmmount[index]}";
    }
}
