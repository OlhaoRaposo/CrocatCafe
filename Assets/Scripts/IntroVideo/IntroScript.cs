using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    public VideoPlayer player;
    void Start () 
    {
        StartCoroutine(streamVideo());
        StartCoroutine(StartVideo());
    }
    private IEnumerator StartVideo()
    {
        yield return new WaitForSeconds(.2f);
        player.Play();

    }

    private IEnumerator streamVideo()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(9.4f);
        Cursor.visible = true;
        SceneManager.LoadScene ("MainMenu");
    }
}
