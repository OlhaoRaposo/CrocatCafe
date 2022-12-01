using UnityEngine;
using UnityEngine.UI;

public class GardenScript : MonoBehaviour
{
    [SerializeField] private GameObject[] plants;
    [SerializeField] private int[] availableAmmount;
    [SerializeField] private GameObject currentPot;


    [SerializeField] private GameObject myPanel;
    [SerializeField] private GameObject[] buttons;
    public static GardenScript instance;
    private void Start()
    {
        availableAmmount = new int[plants.Length];
        for (int i = 0; i < availableAmmount.Length; i++)
        {
            availableAmmount[i] = 5;
        }
        instance = this;
        //carregar sementes do inventário
    }

    public void OpenUi(GameObject pot)
    {
        currentPot = pot;
        int aux = 0;
        for (int i = 0; i < buttons.Length; i++)//Limpa Tudo
        {
            Button currentButton = buttons[i].GetComponent<Button>();
            Text currentText = buttons[i].GetComponentInChildren<Text>();

            currentButton.onClick.RemoveAllListeners();
            currentText.text = "Vazio";
        }

        for (int i = 0; i < plants.Length; i++)//Registra tudo disponível
        {
            if (availableAmmount[i] > 0)
            {
                int value = i;
                Button currentButton = buttons[aux].GetComponent<Button>();
                currentButton.onClick.AddListener(() => SummonPlant(value));

                Text currentText = buttons[aux].GetComponentInChildren<Text>();
                currentText.text = $"{plants[i].GetComponent<Plant>().myName}: {availableAmmount[i]}";

                aux++;
            }
        }
        myPanel.SetActive(true);
    }

    public void BuySeed(int seedId)
    {
        GameObject armazen = GameObject.Find("ArmazenManager");
        if (armazen.GetComponent<Armazen>().money >= plants[seedId].GetComponent<Plant>().plantValue) {
            armazen.GetComponent<Armazen>().money -= plants[seedId].GetComponent<Plant>().plantValue;
            availableAmmount[seedId] += 1;
            armazen.GetComponent<Armazen>().AtualizaTxt();
        }
    }

    public void SetDestinationToPot(GameObject clickedPot, int timeSpent)
    {
        GameObject cat = GameObject.Find("Cat");
        cat.GetComponent<NavMeshScript>().AddDestination(clickedPot, timeSpent);
    }
    public void SummonPlant(int plant)
    {
        Pot potCode = currentPot.GetComponent<Pot>();
        potCode.seed = plants[plant];
        potCode.InteractWithSeed();
        
        availableAmmount[plant]--;

        myPanel.SetActive(false);
    }
}
