using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    [Header("Health")]
    public int hp = 5;

    [Header("Movement")]
    public float speed = 3f;

    [Header("Audio")]
    public AudioClip hitSound;
    public AudioClip deathSound;

    Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        // เสียงตอนมอนโดนยิง
        if (hitSound != null)
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
        }

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // เพิ่มคะแนน
        EnemyScore score = GetComponent<EnemyScore>();

        if (score != null && ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(score.scoreValue);
        }

        // เสียงตอนมอนตาย
        if (deathSound != null)
        {
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }

        Destroy(gameObject);
    }
}
