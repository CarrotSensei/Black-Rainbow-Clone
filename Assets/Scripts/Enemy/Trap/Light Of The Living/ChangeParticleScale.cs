using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeParticleScale : MonoBehaviour
{
    [SerializeField] private float scaleIncrease = 0.1f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRange = 50f;
    public static float localScale;

    public void ExpandScale()
    {
        transform.localScale = new Vector2(Mathf.Clamp(transform.localScale.x + scaleIncrease, minRange, maxRange), Mathf.Clamp(transform.localScale.y + scaleIncrease, minRange, maxRange));
        localScale = transform.localScale.x;
    }

    public void ShrinkScale()
    {
        transform.localScale = new Vector2(Mathf.Clamp(transform.localScale.x - scaleIncrease, minRange, maxRange), Mathf.Clamp(transform.localScale.y - scaleIncrease, minRange, maxRange));
        localScale = transform.localScale.x;
    }
}
