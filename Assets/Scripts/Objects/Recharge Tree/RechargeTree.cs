using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTree : MonoBehaviour
{
    public static bool isHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isHit = true;
            Timer2.triggerFadeOut = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isHit = false;
        }
    }

    private void FixedUpdate()
    {
        if(isHit == true)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime + 0.5f, 0, Timer.startingTime);
        }
    }
}
