using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTreeParticles : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = RechargeTree.powerRemaining / 2;
    }
}
