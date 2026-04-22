using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalPlanets = 5;
    private int clearedPlanets = 0;

    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    // 🔫 เพิ่มคะแนน
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    // 🌍 เคลียร์ดาว
    public void PlanetCleared()
    {
        clearedPlanets++;
        Debug.Log("Cleared: " + clearedPlanets + "/" + totalPlanets);

        if (clearedPlanets >= totalPlanets)
        {
            WinGame();
        }
    }

    // 🏆 ชนะ
    void WinGame()
    {
        Debug.Log("YOU WIN!");
        // เปลี่ยน Scene ไปเครดิต
        // SceneManager.LoadScene("CreditScene");
        Time.timeScale = 0f;
    }

    // 💀 แพ้
    public void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}
