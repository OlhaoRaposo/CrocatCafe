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
        Invoke("RessumonButton", 2.0f);
        if (hasCompletedTutorial == false)
        {
            switch (tutorialProgress)
            {
                case 2:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 3:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 4:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 5:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 7:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 8:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 9:
                    {
                        tutorialWindow.SetActive(false);
                        return;
                    }
                case 12:
                    {
                        tutorialWindow.SetActive(false);
                        hasCompletedTutorial = true;
                        //tutorialProgress = 0;
                        return;
                    }
            }
            if (hasCompletedTutorial == false)
            {
                AdvanceTutorial();
            }
        }
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

    public void OpenTutorialWindow()
    {
        tutorialWindow.SetActive(true);
    }

    private void RessumonButton()
    {
        progressButton.gameObject.SetActive(true);
    }
}
