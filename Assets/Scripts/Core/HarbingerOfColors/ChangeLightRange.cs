using UnityEngine;
public class ChangeLightRange : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D myLight;
    [SerializeField] private float rangeIncrease = 0.05f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRangeOuter = 1.2f;
    [SerializeField] private float maxRangeInner = 1f;
    private float startTime;

    private void Start()
    {
        myLight = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    /*private void FixedUpdate()
    {
        
        if (Input.GetKey("e") && Timer.timeIsZero == false)
        {
            if(myLight != null)
            {
                ExpandLightRange();
            }  
        }
        if (Input.GetKey("q") && Timer.timeIsZero == false)
        {
            if (myLight != null)
            {
                ShrinkLightRange();
            }
        }
    }*/

    public void ExpandLightRange()
    {
        myLight.pointLightInnerRadius = Mathf.Clamp(myLight.pointLightOuterRadius - 0.5f + rangeIncrease, minRange, maxRangeInner);
        myLight.pointLightOuterRadius = Mathf.Clamp(myLight.pointLightOuterRadius + rangeIncrease, minRange, maxRangeOuter);
    }


    public void ShrinkLightRange()
    {
        myLight.pointLightInnerRadius = Mathf.Clamp(myLight.pointLightOuterRadius - 0.5f - rangeIncrease, minRange, maxRangeInner);
        myLight.pointLightOuterRadius = Mathf.Clamp(myLight.pointLightOuterRadius - rangeIncrease, minRange, maxRangeOuter);
    }

}