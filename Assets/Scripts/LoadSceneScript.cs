using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneScript : MonoBehaviour
{
    //Pega uma string como referencia pra dar Load
    //essa string e passada no proprio botao que irá carregar a cena.
    public void LoadScene(string sceneName) {
        if (SceneManager.GetActiveScene().name != sceneName) {
            SceneManager.LoadScene(sceneName);
        }else
            return;
    }
}
