using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinParticleBurst : MonoBehaviour
{
    private ParticleSystem coinBurst;

    void Awake()
    {
        coinBurst = gameObject.GetComponent<ParticleSystem>();
        coinBurst.Stop();
    }

    void Start()
    {
        coinBurst = gameObject.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (CoinPicker.triggerParticles)
        {
            CoinPicker.triggerParticles = false;
            coinBurst.Play();
        }
    }
}
