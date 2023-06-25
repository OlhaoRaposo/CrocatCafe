using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveRestart : MonoBehaviour
{
    private string dirPath;
    public void RestartSave()
    {
        dirPath = Application.dataPath + "/save.txt";
        File.Delete(dirPath);
    }

   public void playAudio(string a)
    {
        AudioBoard.instance.PlayAudio(a);
    }
}
