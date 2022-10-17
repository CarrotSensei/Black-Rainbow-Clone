using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrap : MonoBehaviour
{
    [SerializeField] private CMShake shakeCam;
    public static bool isHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            isHit = true;
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
        if (isHit == true && Timer.currentTime !=0)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime - 0.3f, 0, Timer.startingTime);
            shakeCam.CamShakeZoom();
        }
    }
}
