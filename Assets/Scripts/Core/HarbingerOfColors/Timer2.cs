using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Timer2 : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI uiText;

    private float startingDuration = Timer.startingTime;
    public static float remainingDuration;

    AudioSource m_MyAudioSource;
    private bool playsSong = false;
    private bool songFinished = false;
    public static bool triggerFadeOut = false;

    private CMShake cm;

    private void Start()
    {
        Being(startingDuration);
        m_MyAudioSource = GetComponent<AudioSource>();
        cm = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CMShake>();
    }

    private void Being(float second)
    {
        remainingDuration = second;
    }

    private void FixedUpdate()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (Timer.pauseTimer == false)
        {
            uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
            uiFill.fillAmount = Mathf.InverseLerp(0, startingDuration, remainingDuration);
            remainingDuration = Mathf.Clamp(Timer.currentTime, 0, startingDuration);
            if (Timer.currentTime == 0 && playsSong == false && songFinished == false)
            {
                StartCoroutine(WaitBeforeSongEnds(120));
                cm.CamFocusOut1();
            }

            if (triggerFadeOut == true)
            {
                StartCoroutine(FadeOutSong(2, 20));
                cm.CamFocusOutSnapBackToIdle1();
            }

            /*increase starting duration if current duration goes over the starting one
            remainingDuration = Timer.currentTime;
            if (remainingDuration > startingDuration)
            {
                startingDuration = remainingDuration;
            }
            */
        }
    }


    IEnumerator WaitBeforeSongEnds(float time)
    {
        BackgroundMusicManager.triggerFadeOut = true;
        playsSong = true;
        m_MyAudioSource.Play();
        yield return new WaitForSeconds(time); 
        if (Timer.currentTime == 0)
        {
            Debug.Log("kill player");
        }
        songFinished = true;
        playsSong = false;
    }       

    IEnumerator FadeOutSong(float time, float smoothness)
    {
        BackgroundMusicManager.triggerFadeIn = true;
        triggerFadeOut = false;
        WaitForSeconds wfs = new WaitForSeconds(time / smoothness);
        for (int i = 0; i < smoothness; i++)
        {
            m_MyAudioSource.volume = m_MyAudioSource.volume - (1 / smoothness);
            yield return wfs;
        }
        m_MyAudioSource.Stop();
        m_MyAudioSource.volume = 1;
        playsSong = false;
    }


    /*
    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >=0)
        {
            if(Timer.pauseTimer == false)
            {
                uiText.text = $"{remainingDuration / 60:00} : {remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, startingDuration, remainingDuration);
                remainingDuration = Timer.currentTime;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }
    */
}
