using UnityEngine;

public class HealthFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(-1.5f, 0.5f, 0);

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position
                + target.right * offset.x
                + target.up * offset.y;
        }
    }
}
