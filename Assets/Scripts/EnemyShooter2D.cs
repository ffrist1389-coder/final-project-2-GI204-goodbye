using UnityEngine;

public class EnemyShooter2D : MonoBehaviour
{
    public float speed = 2f;

    public GameObject bulletPrefab;

    private Transform player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("หา Player ไม่เจอ!");
        }

        if (bulletPrefab == null)
        {
            Debug.LogError("bulletPrefab = NULL (ตัว spawn ไม่มีค่า!)");
        }

        timer = 1f;
    }

    void Update()
    {
        if (player == null) return;

        // 👉 ไล่
        Vector2 dir = (player.position - transform.position).normalized;
        transform.Translate(dir * speed * Time.deltaTime);

        // 👉 หัน
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // 👉 ยิงแบบบังคับทุก 1 วิ
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            Shoot();
            timer = 1f;
        }
    }

    void Shoot()
    {
        Debug.Log("ยิง!!");

        if (bulletPrefab == null)
        {
            Debug.LogError("ยิงไม่ได้ เพราะ bulletPrefab ไม่มี!");
            return;
        }

        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
