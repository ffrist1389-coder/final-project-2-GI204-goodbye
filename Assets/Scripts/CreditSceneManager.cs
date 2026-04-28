using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    public void BackToMenu()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }

        Time.timeScale = 1f;
        Invoke(nameof(LoadMainMenu), 0.15f);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}