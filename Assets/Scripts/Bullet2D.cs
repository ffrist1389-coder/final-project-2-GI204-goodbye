using UnityEngine;

public class Bullet2D : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 3f;

    void Start()
    {
        // ลบตัวเองหลัง 3 วิ (กันรก)
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // เคลื่อนที่ไปข้างหน้า (แกน Y)
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy2D enemy = other.GetComponent<Enemy2D>();

            if (enemy != null)
            {
                enemy.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
