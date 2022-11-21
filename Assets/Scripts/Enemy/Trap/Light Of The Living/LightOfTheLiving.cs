using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOfTheLiving : MonoBehaviour
{
    [SerializeField] private CMShake shakeCam;
    [SerializeField] private ChangeParticleScale changeParticleScale;
    [SerializeField] private ChangeLightRange changeLightRange;
    [SerializeField] private ChangeCircleColliderRange changeCircleColliderRadius;
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
        if (isHit == true && Timer.currentTime != 0)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime - 0.3f, 0, Timer.startingTime);
            shakeCam.CamShakeZoom();
            changeLightRange.ExpandLightRange();
            changeParticleScale.ExpandScale();
            changeCircleColliderRadius.ExpandRadius();
        }
    }
}
