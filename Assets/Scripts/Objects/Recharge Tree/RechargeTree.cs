using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTree : MonoBehaviour
{
    [SerializeField] private float startingPower = 200f;
    public static float startingPower1;
    public static bool isHit;
    public static float powerRemaining;

    private void Start()
    {
        startingPower1 = startingPower;
        powerRemaining = startingPower;
    }

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
        if(isHit == true && powerRemaining != 0 && Timer.currentTime <= Timer.startingTime - 0.5f)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime + 0.5f, 0, Timer.startingTime);
            powerRemaining = Mathf.Clamp(powerRemaining - 0.5f, 0, startingPower);
        }
    }
}
