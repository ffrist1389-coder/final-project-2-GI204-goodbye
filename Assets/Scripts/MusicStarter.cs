using UnityEngine;

public class MusicStarter : MonoBehaviour
{
    public AudioClip musicClip;

    void Start()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayMusic(musicClip);
        }
    }
}