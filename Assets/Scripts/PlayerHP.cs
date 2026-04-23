using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 10;
    public int currentHP;

    public HealthBar healthBar;

    void Start()
    {
        currentHP = maxHP;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHP);
            healthBar.SetHealth(currentHP);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHP);
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHP += amount;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHP);
        }
    }

    void Die()
    {
        if (GameStateManager.instance != null)
        {
            GameStateManager.instance.GameOver(transform.position);
        }

        gameObject.SetActive(false);
    }
}
