using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownParticles : MonoBehaviour
{
    private ParticleSystem powerDownBurst;

    void Awake()
    {
        powerDownBurst = gameObject.GetComponent<ParticleSystem>();
        powerDownBurst.Stop();
    }

    void Start()
    {
        powerDownBurst = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (ElectricTrap.triggerDownParticles == true || MeleeEnemy.triggerPowerDownParticles == true)
        {
            MeleeEnemy.triggerPowerDownParticles = false;
            powerDownBurst.Play();
        }
    }
}
