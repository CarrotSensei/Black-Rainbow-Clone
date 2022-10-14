using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownParticles : MonoBehaviour
{
    private ParticleSystem powerDown;

    void Awake()
    {
        powerDown = gameObject.GetComponent<ParticleSystem>();
        powerDown.Stop();
    }

    void Start()
    {
        powerDown = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (MeleeEnemy.triggerPowerDownParticles == true || ElectricTrap.isHit == true)
        {
            MeleeEnemy.triggerPowerDownParticles = false;
            powerDown.Play();
        }
    }
}
