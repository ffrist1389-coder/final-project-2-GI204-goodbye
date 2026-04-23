using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(1);
            }

            Destroy(gameObject);
        }
    }
}
