using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePointL;
    public Transform firePointR;
    public float fireRate = 0.2f;

    private float nextFire;

    void Update()
    {
        // 🚀 เดินหน้า (W)
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }

        // 🔄 หมุน (A / D)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }

        // 🔫 ยิง (คลิกซ้าย)
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePointL == null || firePointR == null)
        {
            Debug.LogWarning("ยังไม่ได้ตั้งค่า Bullet หรือ FirePoint");
            return;
        }

        // ยิงออก 2 ข้าง
        Instantiate(bulletPrefab, firePointL.position, firePointL.rotation);
        Instantiate(bulletPrefab, firePointR.position, firePointR.rotation);
    }
}
