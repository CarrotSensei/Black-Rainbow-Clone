using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticleBurst : MonoBehaviour
{
    private ParticleSystem powerUpBurst;

    void Awake()
    {
        powerUpBurst = gameObject.GetComponent<ParticleSystem>();
        powerUpBurst.Stop();
    }

    void Start()
    {
        powerUpBurst = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (CoinPicker.triggerParticles == true || RechargeTree.isHit == true)
        {
            CoinPicker.triggerParticles = false;
            powerUpBurst.Play();
        }
    }
}
