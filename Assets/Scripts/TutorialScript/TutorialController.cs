using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private string[] currentText;
    [SerializeField] private Text activeText;
    [SerializeField] private GameObject tutorialWindow;
    public Button progressButton;
    public int tutorialProgress = 0;
    [SerializeField] private bool hasCompletedTutorial = false;
    public static TutorialController instance;

    private void Start()
    {
        instance = this;
        UpdateText();
        OpenTutorialWindow();
    }

    public void NextText()
    {
        Invoke("RessumonButton", 1.0f);
        if (hasCompletedTutorial == false)
        {
            AdvanceTutorial();
        }
    }

    public void AdvanceTutorial()
    {
        tutorialProgress++;
        switch (tutorialProgress)
        {
            case 26:
            {
                tutorialWindow.SetActive(false);
                EditMode.instance.ToggleCanvas(false);
            }
            return;
        }
        UpdateText();
    }
    private void UpdateText()
    {
        activeText.text = currentText[tutorialProgress];
    }

    public void OpenTutorialWindow()
    {
        tutorialWindow.SetActive(true);
        EditMode.instance.ToggleCanvas(true);
        Debug.Log("A");
    }

    private void RessumonButton()
    {
        progressButton.gameObject.SetActive(true);
    }
}
