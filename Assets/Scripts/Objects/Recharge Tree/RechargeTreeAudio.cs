using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTreeAudio : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }


    public void FixedUpdate()
    {
        m_MyAudioSource.volume = RechargeTree.powerRemaining / RechargeTree.startingPower1;
    }
}
