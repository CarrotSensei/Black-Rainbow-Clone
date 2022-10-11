using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarbingerOfColorsManager : MonoBehaviour
{
    [SerializeField] private ChangeScale expandScale;
    [SerializeField] private ChangeLightRange expandLightRange;
    [SerializeField] private ChangeParticleRadius expandParticleRadius;
    [SerializeField] private NPCDetector expandScale1;

    [SerializeField] private ChangeScale shrinkScale;
    [SerializeField] private ChangeLightRange shrinkLightRange;
    [SerializeField] private ChangeParticleRadius shrinkParticleRadius;
    [SerializeField] private NPCDetector shrinkScale1;


    private void FixedUpdate()
    {
        if (Input.GetKey("e") && Timer.timeIsZero == false)
        {
            expandScale.ExpandScale();
            expandLightRange.ExpandLightRange();
            expandParticleRadius.ExpandParticleRadius();
            expandScale1.ExpandScale();
        }
        if (Input.GetKey("q") && Timer.timeIsZero == false)
        {
            shrinkScale.ShrinkScale();
            shrinkLightRange.ShrinkLightRange();
            shrinkParticleRadius.ShrinkParticleRadius();
            shrinkScale1.ShrinkScale();
        }
    }
}
