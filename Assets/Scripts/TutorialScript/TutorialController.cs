using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField]private string[] currentText;
    [SerializeField]private Text activeText;
    public int tutorialProgress = 0;
    public static TutorialController instance;

    private void Start()
    {
        instance = this;
        UpdateText();
    }
    public void AdvanceTutorial()
    {
        tutorialProgress++;
        UpdateText();
    }
    private void UpdateText()
    {
        activeText.text = currentText[tutorialProgress];
    }
}
