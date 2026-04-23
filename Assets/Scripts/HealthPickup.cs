using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();

            if (playerHP != null)
            {
                playerHP.Heal(healAmount);
            }

            Destroy(gameObject);
        }
    }
}
