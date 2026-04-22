using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 8f;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ⴹ Player!");

            PlayerHP hp = other.GetComponent<PlayerHP>();

            if (hp != null)
            {
                hp.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
