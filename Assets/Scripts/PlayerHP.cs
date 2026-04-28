using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [Header("Health")]
    public int maxHP = 10;
    public int currentHP;

    [Header("UI")]
    public HealthBar healthBar;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip explosionSound;

    private bool isDead = false;

    void Start()
    {
        currentHP = maxHP;
        isDead = false;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHP);
            healthBar.SetHealth(currentHP);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHP -= damage;

        if (currentHP < 0)
        {
            currentHP = 0;
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHP);
        }

        // เสียงตอนโดนยิง
        if (audioSource != null && hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }

        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHP += amount;

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHP);
        }

        Debug.Log("Heal! HP = " + currentHP);
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        // ใช้แบบนี้เพื่อให้เสียงระเบิดยังดัง แม้ Player จะถูกปิด
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        if (GameStateManager.instance != null)
        {
            GameStateManager.instance.GameOver(transform.position);
        }

        gameObject.SetActive(false);
    }
}
