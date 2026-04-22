using UnityEngine;

public class ThrusterEffect : MonoBehaviour
{
    public ParticleSystem thruster;

    void Start()
    {
        // เริ่มต้นให้มันว่างเปล่าเลย
        thruster.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        thruster.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (!thruster.gameObject.activeSelf)
            {
                thruster.gameObject.SetActive(true);
                thruster.Play();
            }
        }
        else
        {
            // 🔥 อันนี้คือจุดสำคัญ
            thruster.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            thruster.gameObject.SetActive(false);
        }
    }
}
