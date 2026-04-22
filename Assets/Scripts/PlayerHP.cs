using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHP = 5;
    public int currentHP;

    public HealthBar healthBar;

    void Start()
    {
        currentHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        healthBar.SetHealth(currentHP);

        if (currentHP <= 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
