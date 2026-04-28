using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject youWinText;
    public GameObject restartButton;
    public GameObject mainMenuButton;

    [Header("Explosion")]
    public GameObject playerExplosionPrefab;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip buttonClickSound;

    private bool gameEnded = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        Time.timeScale = 1f;

        if (gameOverText != null) gameOverText.SetActive(false);
        if (youWinText != null) youWinText.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false);
        if (mainMenuButton != null) mainMenuButton.SetActive(false);
    }

    public void GameOver(Vector3 playerPosition)
    {
        if (gameEnded) return;
        gameEnded = true;

        if (playerExplosionPrefab != null)
        {
            GameObject explosion = Instantiate(playerExplosionPrefab, playerPosition, Quaternion.identity);
            Destroy(explosion, 2f);
        }

        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        if (gameOverText != null) gameOverText.SetActive(true);

        ShowEndButtons();

        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (youWinText != null) youWinText.SetActive(true);

        ShowEndButtons();

        Time.timeScale = 0f;
    }

    void ShowEndButtons()
    {
        if (restartButton != null) restartButton.SetActive(true);
        if (mainMenuButton != null) mainMenuButton.SetActive(true);
    }

    public void RestartGame()
    {
        PlayButtonSound();
        StartCoroutine(RestartAfterSound());
    }

    IEnumerator RestartAfterSound()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void GoToMainMenu()
    {
        PlayButtonSound();
        StartCoroutine(MainMenuAfterSound());
    }

    IEnumerator MainMenuAfterSound()
    {
        yield return new WaitForSecondsRealtime(0.2f);

        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void PlayButtonSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}