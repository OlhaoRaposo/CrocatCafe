using UnityEngine;

public class ObjectScript : IObjectID
{
    [Header("OBJECT IDENTIFTY")]
    public bool isOven, isPot, isFurnace, isBarrel, isKneader, isJuicer, isRefrigerator,isShowcase;
    private void Start()
    {
        objectId = objectType + objectNum.ToString() + objectRotation;

        if (isPot)
        {
            if (TutorialController.instance.tutorialProgress < 3)
            {
                TutorialController.instance.AdvanceTutorial();
                TutorialController.instance.OpenTutorialWindow();
            }
        }
        else if (isFurnace)
        {
            if (TutorialController.instance.tutorialProgress < 6)
            {
                TutorialController.instance.AdvanceTutorial();
                TutorialController.instance.OpenTutorialWindow();
            }
        }
        else if (isShowcase)
        {
            if (TutorialController.instance.tutorialProgress < 10)
            {
                TutorialController.instance.AdvanceTutorial();
                TutorialController.instance.OpenTutorialWindow();
            }
        }
    }

    public void ObjectInteract()
    {
        if (EditMode.instance.isEditing == false)
        {
            GameObject gmbj;
            if (isPot)
            {
                if (gameObject.GetComponent<Pot>().isOccupied == false)
                {
                    gmbj = GameObject.Find("GardenManager");
                    gmbj.GetComponent<GardenScript>().OpenUi(gameObject);
                }
                else
                {
                    gameObject.GetComponent<Pot>().InteractWithSeed();
                }
            }
            else
            {
                gameObject.GetComponent<Bench>().OpenUI();
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
