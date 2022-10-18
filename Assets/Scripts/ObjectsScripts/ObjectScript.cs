using UnityEngine;

public class ObjectScript :  IObjectID
{
    [Header("OBJECT IDENTIFTY")] 
    public bool isOven, isPot;
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
                gmbj.GetComponent<OvenScript>().OpenUi();
            }
            else if(isPot)
            {
                gameObject.GetComponent<PotScript>().PlantSeed();
            }
        }
    }
}
