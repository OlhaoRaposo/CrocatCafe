using Unity.Mathematics;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private GameObject armazen;
    [SerializeField]
    private int pageIndex = 1;
    public GameObject[] objects;
    public GameObject[] pages;

    private void Awake()
    {
        armazen = GameObject.Find("ArmazenManager");
    }
    public void BuyObject(string code)
    {
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i].GetComponent<ObjectScript>().objectId == code)
            {
                if (ArmazenManager.instance.money >= objects[i].GetComponent<ObjectScript>().objectValue)
                {
                    

                    for (int j = 0; j < EditMode.instance.gridList.Length; j++)
                    {
                        if (EditMode.instance.gridList[j].layer == objects[i].layer)
                        {
                            GridCell[] cells = EditMode.instance.gridList[j].GetComponentsInChildren<GridCell>();

                            foreach (GridCell cell in cells)
                            {
                                if (cell.isOccupied == false)
                                {
                                    GameObject currentObject = Instantiate(objects[i], cell.transform.position, quaternion.identity);
                                    ArmazenManager.instance.money -= objects[i].GetComponent<ObjectScript>().objectValue;
                                    ArmazenManager.instance.UpdateMoneyText();
                                    AudioBoard.instance.PlayAudio("SFX_UI_Shop");

                                    cell.isOccupied = true;
                                    cell.currentObject = currentObject;

                                    currentObject.GetComponent<DragableObject>().currentCell = cell;
                                    return;
                                }
                            }
                            Debug.Log("Todos os slots estão ocupados.");
                        }
                    }
                }
            }
        }
    }

    public void BuySeed(int seedId)
    {
        GardenScript garden = GameObject.Find("GardenManager").GetComponent<GardenScript>();
        if (ArmazenManager.instance.money >= garden.plants[seedId].GetComponent<Plant>().data.price)
        {
            ArmazenManager.instance.money -= garden.plants[seedId].GetComponent<Plant>().data.price;
            ArmazenManager.instance.UpdateMoneyText();
            AudioBoard.instance.PlayAudio("SFX_UI_Shop");
            garden.availableAmmount[seedId] += 1;
        }
    }
    public void NextPage(int page)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        if (pageIndex + page >= pages.Length)
        {
            pageIndex = 0;
        }
        else if (pageIndex + page < 0)
        {
            pageIndex = pages.Length - 1;
        }
        else
            pageIndex += page;
        pages[pageIndex].SetActive(true);
    }
}
