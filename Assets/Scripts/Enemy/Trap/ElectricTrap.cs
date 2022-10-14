using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    private bool isHit = false;
    public static bool triggerDownParticles = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isHit = true;
            StartCoroutine(WaitBeforeReducingTime(0.01f));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isHit = false;
        }
    }

    IEnumerator WaitBeforeReducingTime(float time)
    {
        int i;
        for (i = 0; i < Mathf.Infinity; i++)
        {
            if (Timer.currentTime == 0)
            {
                yield return null;
            }

            if (isHit == true)
            {
                triggerDownParticles = true;
                Timer.currentTime = Mathf.Clamp(Timer.currentTime - 0.1f, 0, 100);
                yield return new WaitForSeconds(time);
            }
            else
            {
                triggerDownParticles = false;
                yield return null;
            }
        }
    }
}
