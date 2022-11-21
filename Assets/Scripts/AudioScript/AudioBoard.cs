using UnityEngine;
public class AudioBoard : MonoBehaviour
{
    [SerializeField]private AudioSource[] audios;
    public static AudioBoard instance;

    private void Start()
    {
        instance = this;
    }

    public void PlayAudio(string audioName)
    {
        foreach (AudioSource audio in audios)
        {
            if(audioName == audio.name)
            {
                audio.Play();
                return;
            }
        }
    }
}
