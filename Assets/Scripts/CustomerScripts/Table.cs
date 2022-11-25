using UnityEngine;

public class Table : MonoBehaviour
{
    public int capacity;
    private void Start()
    {
        TablesScript.instance.AddTable();
        if (TutorialController.instance.tutorialProgress < 11)
        {
            TutorialController.instance.AdvanceTutorial();
            TutorialController.instance.OpenTutorialWindow();
        }
    }

    private void OnDestroy()
    {
        TablesScript.instance.DeleteTable();
    }
}
