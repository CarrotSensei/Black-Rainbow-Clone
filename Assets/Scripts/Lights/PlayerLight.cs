using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] private float rangeIncrease = 0.01f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRangeOuter = 1.2f;
    [SerializeField] private float maxRangeInner = 1f;

    private void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }


    private void FixedUpdate()
    {
        if (Timer.currentTime != 0)
        {
            ExpandLightRange();
        }
        else
        {
            ShrinkLightRange();
        }
    }

    private void ExpandLightRange()
    {
        myLight.pointLightInnerRadius = Mathf.Clamp(myLight.pointLightOuterRadius + rangeIncrease, minRange, maxRangeInner);
        myLight.pointLightOuterRadius = Mathf.Clamp(myLight.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
    }

    private void ShrinkLightRange()
    {
        myLight.pointLightInnerRadius = Mathf.Clamp(myLight.pointLightOuterRadius - rangeIncrease, minRange, maxRangeInner);
        myLight.pointLightOuterRadius = Mathf.Clamp(myLight.pointLightOuterRadius - rangeIncrease, minRange, maxRangeOuter);
    }
}
