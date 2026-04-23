using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    [Header("UI")]
    public GameObject gameOverText;
    public GameObject youWinText;

    [Header("Explosion")]
    public GameObject playerExplosionPrefab;

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

        if (gameOverText != null)
            gameOverText.SetActive(false);

        if (youWinText != null)
            youWinText.SetActive(false);
    }

    public void GameOver(Vector3 playerPosition)
    {
        if (gameEnded) return;
        gameEnded = true;

        if (playerExplosionPrefab != null)
        {
            Instantiate(playerExplosionPrefab, playerPosition, Quaternion.identity);
        }

        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (youWinText != null)
        {
            youWinText.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
