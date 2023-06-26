using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    //Pega uma string como referencia pra dar Load
    //essa string e passada no proprio botao que irá carregar a cena.
    [SerializeField]
    private GameObject escMenu;
    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
            return;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && EditMode.instance.isOnCanvas == false)
        {
            escMenu.SetActive(!escMenu.activeSelf);
            EditMode.instance.ToggleCanvas(escMenu.activeSelf);
        }
    }

    public void QuitGame()
    {
        SaveGame.instance.Save();
        Application.Quit();
    }
}
