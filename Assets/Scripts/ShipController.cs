using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    [Header("Map Bounds")]
    public float minX = -30f;
    public float maxX = 30f;
    public float minY = -20f;
    public float maxY = 20f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePointL;
    public Transform firePointR;
    public float fireRate = 0.2f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip shootSound;

    private float nextFire;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePointL == null || firePointR == null)
        {
            Debug.LogWarning("ยังไม่ได้ตั้งค่า Bullet หรือ FirePoint");
            return;
        }

        Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
        Instantiate(bulletPrefab, firePointR.position, firePointR.rotation);

        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
