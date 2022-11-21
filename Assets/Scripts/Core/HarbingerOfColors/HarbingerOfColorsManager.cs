using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarbingerOfColorsManager : MonoBehaviour
{
    [SerializeField] private ChangeScale changeScale;
    [SerializeField] private ChangeLightRange changeLightRange;
    [SerializeField] private ChangeParticleRadius changeParticleRadius;
    [SerializeField] private NPCDetector changeScale1;


    private void FixedUpdate()
    {
        if (Input.GetKey("e") && Timer.timeIsZero == false)
        {
            changeScale.ExpandScale();
            changeLightRange.ExpandLightRange();
            changeParticleRadius.ExpandParticleRadius();
            changeScale1.ExpandScale();
        }
        if (Input.GetKey("q") && Timer.timeIsZero == false)
        {
            changeScale.ShrinkScale();
            changeLightRange.ShrinkLightRange();
            changeParticleRadius.ShrinkParticleRadius();
            changeScale1.ShrinkScale();
        }
    }
}
