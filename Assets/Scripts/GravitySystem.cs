using UnityEngine;

public class GravitySystem : MonoBehaviour
{
    public float planetMass = 100f; // ลองลดเหลือสัก 100 ก่อน
    public float minDistance = 1f;  // ระยะต่ำสุดเพื่อไม่ให้แรงดีด (สำคัญ!)
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject planet in planets)
        {
            ApplyGravity(planet);
        }
    }

    void ApplyGravity(GameObject planet)
    {
        Vector2 direction = planet.transform.position - transform.position;
        float distance = direction.magnitude;

        // --- จุดที่ต้องแก้ ---
        // ถ้าอยู่ใกล้เกินไป ให้ใช้ค่า minDistance แทน เพื่อไม่ให้แรงเป็น Infinity
        float effectiveDistance = Mathf.Max(distance, minDistance);

        if (distance == 0f) return;

        // คำนวณแรง (เพิ่มตัวหารเพื่อให้นุ่มขึ้น)
        float forceMagnitude = planetMass / (effectiveDistance * effectiveDistance);
        Vector2 force = direction.normalized * forceMagnitude;

        rb.AddForce(force);
    }
}
