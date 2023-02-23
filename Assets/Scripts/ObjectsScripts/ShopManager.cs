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
                if (armazen.GetComponent<Armazen>().money >= objects[i].GetComponent<ObjectScript>().objectValue)
                {
                    armazen.GetComponent<Armazen>().money -= objects[i].GetComponent<ObjectScript>().objectValue;
                    armazen.GetComponent<Armazen>().AtualizaTxt();

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
