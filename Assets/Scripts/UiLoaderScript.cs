using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiLoaderScript : MonoBehaviour
{
    //Public Vars
    public GameObject firstUiGmbj;
    public GameObject secondUiGmbj;



    //Private Vars
    private bool firstIsOpen = false;
    //private bool secondIsOpen = false;

    //Abre a segunda ui fechando a primeira e vice versa.
    public void OpenUiAndCloseFirst()
    {
        if (!firstIsOpen)
        {
            firstUiGmbj.SetActive(true);
            secondUiGmbj.SetActive(false);
            firstIsOpen = true;
        }
        else if (firstIsOpen)
        {
            firstIsOpen = false;
            firstUiGmbj.SetActive(false);
            secondUiGmbj.SetActive(true);
        }
    }
    //Apenas Abre uma ui
    public void OpenUi()
    {
        firstUiGmbj.SetActive(true);
    }



    //Abre uma Ui mantendo a primeira ativa e assim por diante.
    //Ui é atribuida ao botao.
    public void OpenAbove(GameObject next)
    {
        if (!firstIsOpen)
        {
            firstUiGmbj.SetActive(true);
            firstIsOpen = true;
        }
        else if (firstIsOpen)
        {
            next.gameObject.SetActive(true);
        }
    }
    //Fecha uma Ui por vez.
    //Ui Atribuida ao botao.
    public void CloseTab(GameObject closeTab)
    {
        if (closeTab.activeSelf)
        {
            closeTab.SetActive(false);
        }
    }

}
