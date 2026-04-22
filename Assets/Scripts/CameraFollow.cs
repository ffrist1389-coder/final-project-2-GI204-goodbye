using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ลาก Player มาใส่ช่องนี้
    public float smoothSpeed = 0.125f; // ความนุ่มนวล (น้อย = นุ่มมาก)
    public Vector3 offset = new Vector3(0, 0, -10); // ระยะห่างจากยาน (แกน Z ต้องติดลบ)

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
