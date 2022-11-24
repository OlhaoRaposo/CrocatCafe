using UnityEngine;

public class ObjectScript :  IObjectID
{
    [Header("OBJECT IDENTIFTY")] 
    public bool isOven, isPot, isFurnace, isBarrel, isKneader, isJuicer;
    private void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
    }

    public void ObjectInteract()
    {
        if(EditMode.isEditing == false)
        {
            GameObject gmbj;
            if (isOven)
            {
                gmbj = GameObject.Find("OvenManager");
                gmbj.GetComponent<OvenScript>().OpenUi(gameObject);
            }
            else if(isFurnace)
            {
                gmbj = GameObject.Find("FurnaceManager");
                gmbj.GetComponent<FurnaceScript>().OpenUi(gameObject);
            }
            else if(isBarrel)
            {
                gmbj = GameObject.Find("BarrelManager");
                gmbj.GetComponent<BarrelScript>().OpenUi(gameObject);
            }
            else if(isKneader)
            {
                gmbj = GameObject.Find("KneaderManager");
                gmbj.GetComponent<KneaderScript>().OpenUi(gameObject);
            }
            else if(isJuicer)
            {
                gmbj = GameObject.Find("JuicerManager");
                gmbj.GetComponent<JuicerScript>().OpenUi(gameObject);
            }
            else if(isPot)
            {
                if(gameObject.GetComponent<Pot>().isOccupied == false)
                {
                    gmbj = GameObject.Find("GardenManager");
                    gmbj.GetComponent<GardenScript>().OpenUi(gameObject);
                }
                else
                {
                    gameObject.GetComponent<Pot>().InteractWithSeed();
                }
            }
        }
    }
}
