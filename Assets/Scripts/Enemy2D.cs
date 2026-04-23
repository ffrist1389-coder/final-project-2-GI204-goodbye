using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public int hp = 5;
    public float speed = 3f;

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
        Debug.Log("Enemy HP = " + hp);

        if (hp <= 0)
        {
            EnemyScore score = GetComponent<EnemyScore>();

            if (score != null && ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(score.scoreValue);
            }

            Destroy(gameObject);
        }
    }
}
