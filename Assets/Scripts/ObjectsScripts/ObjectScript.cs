using UnityEngine;

public class ObjectScript :  IObjectID
{
    [Header("OBJECT IDENTIFTY")] 
    public bool isOven;
    private void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;
    }

    public void ObjectInteract()
    {
        if(EditMode.isEditing == false)
        {
            if (isOven)
            {
                GameObject gmbj;
                gmbj = GameObject.Find("OvenManager");
                gmbj.GetComponent<OvenScript>().OpenUi();
            }
        }
    }
}
