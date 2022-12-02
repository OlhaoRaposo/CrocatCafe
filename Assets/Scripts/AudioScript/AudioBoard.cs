using UnityEngine;
public class AudioBoard : MonoBehaviour
{
    [SerializeField]private AudioSource[] audios;
    public static AudioBoard instance;

    private void Start()
    {
        audios = GameObject.FindObjectsOfType<AudioSource>();
        instance = this;
    }

    public void PlayAudio(string audioName)
    {
        foreach (AudioSource audio in audios)
        {
            if(audioName == audio.clip.name)
            {
                audio.Play();
                return;
            }
        }
    }

    public void StopAudio(string audioName)
    {
        foreach (AudioSource audio in audios)
        {
            if(audioName == audio.clip.name)
            {
                audio.Stop();
                return;
            }
        }
    }

    public void ResumeAudio(string audioName)
    {
        foreach (AudioSource audio in audios)
        {
            if(audioName == audio.clip.name)
            {
                audio.UnPause();
                return;
            }
        }
    }

    public void PauseAudio(string audioName)
    {
        foreach (AudioSource audio in audios)
        {
            if(audioName == audio.clip.name)
            {
                audio.Pause();
                return;
            }
        }
    }
}
