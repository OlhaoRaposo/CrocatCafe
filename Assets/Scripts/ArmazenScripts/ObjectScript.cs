using UnityEngine;

public class ObjectScript : IObjectID
{
    [Header("OBJECT IDENTIFTY")]
    public bool isOven, isPot, isFurnace, isBarrel, isKneader, isJuicer, isRefrigerator, isShowcase;
    private void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
        if (isShowcase == true)
        {
            NCustomerManager.instance.allShowCases.Add(gameObject);
        }
    }

    public void ObjectInteract()
    {
        if (EditMode.instance.isEditing == false && EditMode.instance.isOnCanvas == false)
        {
            GameObject gmbj;
            if (isPot)
            {
                if (gameObject.GetComponent<Pot>().isOccupied == false)
                {
                    gmbj = GameObject.Find("GardenManager");
                    gmbj.GetComponent<GardenScript>().OpenUi(gameObject);
                    EditMode.instance.ToggleCanvas(true);
                }
                else
                {
                    gameObject.GetComponent<Pot>().InteractWithSeed();
                }
            }
            else
            {
                gameObject.GetComponent<Bench>().OpenUI();
                EditMode.instance.ToggleCanvas(true);
            }
        }
    }
    private void OnDestroy()
    {
        GameObject armazen = GameObject.Find("ArmazenManager");
        if (armazen != null)
        {
            ArmazenManager.instance.money += objectValue;
            ArmazenManager.instance.UpdateMoneyText();
        }
    }
}
