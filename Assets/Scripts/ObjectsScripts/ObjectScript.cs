using UnityEngine;

public class ObjectScript : IObjectID
{
    [Header("OBJECT IDENTIFTY")]
    public bool isOven, isPot, isFurnace, isBarrel, isKneader, isJuicer, isShowcase;
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
            if (isOven)
            {
                gmbj = GameObject.Find("OvenManager");
                gmbj.GetComponent<OvenScript>().OpenUi(gameObject);
            }
            else if (isFurnace)
            {
                gmbj = GameObject.Find("FurnaceManager");
                gmbj.GetComponent<FurnaceScript>().OpenUi(gameObject);


            }
            else if (isBarrel)
            {
                gmbj = GameObject.Find("BarrelManager");
                gmbj.GetComponent<BarrelScript>().OpenUi(gameObject);
            }
            else if (isKneader)
            {
                gmbj = GameObject.Find("KneaderManager");
                gmbj.GetComponent<KneaderScript>().OpenUi(gameObject);
            }
            else if (isJuicer)
            {
                gmbj = GameObject.Find("JuicerManager");
                gmbj.GetComponent<JuicerScript>().OpenUi(gameObject);
            }
            else if (isPot)
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
        }
    }
    private void OnDestroy()
    {
        GameObject armazen = GameObject.Find("ArmazenManager");
        if (armazen != null)
        {
            GameObject.Find("ArmazenManager").GetComponent<Armazen>().money += objectValue;
            GameObject.Find("ArmazenManager").GetComponent<Armazen>().AtualizaTxt();
        }
    }
}
