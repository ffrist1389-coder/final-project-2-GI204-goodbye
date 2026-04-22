using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int hp = 5;
    public float speed = 3f;

    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            // วิ่งเข้าหาผู้เล่น
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
