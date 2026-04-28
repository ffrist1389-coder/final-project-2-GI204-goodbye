using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject howToPlayPanel;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    public void StartGame()
    {
        PlayButtonSound();
        Invoke(nameof(LoadGameScene), 0.2f);
    }

    void LoadGameScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void OpenHowToPlay()
    {
        PlayButtonSound();

        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
        }
    }

    public void CloseHowToPlay()
    {
        PlayButtonSound();

        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
    }

    public void OpenCredit()
    {
        PlayButtonSound();
        Invoke(nameof(LoadCreditScene), 0.2f);
    }

    void LoadCreditScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("CreditScene");
    }

    public void QuitGame()
    {
        PlayButtonSound();
        Invoke(nameof(QuitAfterSound), 0.2f);
    }

    void QuitAfterSound()
    {
        Application.Quit();
    }

    void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
