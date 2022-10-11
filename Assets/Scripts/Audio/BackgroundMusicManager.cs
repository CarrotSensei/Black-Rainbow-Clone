using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    AudioSource m_MyAudioSource;
    public static bool playsSong = false;
    public static bool triggerFadeOut = false;
    public static bool triggerFadeIn = false;

    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }

    void Update()
    {      
        if (Timer2.remainingDuration != 0 && triggerFadeIn == true)
        {
            StartCoroutine(FadeInSong(4, 20));
        }
        if (Timer2.remainingDuration == 0 && triggerFadeOut == true)
        {
            StartCoroutine(FadeOutSong(2, 20));
        }
    }

    IEnumerator FadeInSong(float time, float smoothness)
    {
        triggerFadeIn = false;
        WaitForSeconds wfs = new WaitForSeconds(time / smoothness);
        for (int i = 0; i < smoothness; i++)
        {
            m_MyAudioSource.volume = Mathf.Clamp(m_MyAudioSource.volume + (1 / smoothness), 0, 0.5f);
            yield return wfs;
        }
    }

    IEnumerator FadeOutSong(float time, float smoothness)
    {
        triggerFadeOut = false;
        WaitForSeconds wfs = new WaitForSeconds(time / smoothness);
        for (int i = 0; i < smoothness; i++)
        {
            m_MyAudioSource.volume = Mathf.Clamp(m_MyAudioSource.volume - (1 / smoothness), 0, 0.5f);
            yield return wfs;
        }
    }
}
