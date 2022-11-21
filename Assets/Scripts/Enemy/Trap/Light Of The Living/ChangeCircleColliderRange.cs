using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCircleColliderRange : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider;
    [SerializeField] private float scaleIncrease = 0.1f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRange = 50f;

    public void ExpandRadius()
    {
        circleCollider.radius = Mathf.Clamp(circleCollider.radius + scaleIncrease, minRange, maxRange);
    }

    public void ShrinkRadius()
    {
        circleCollider.radius = Mathf.Clamp(circleCollider.radius - scaleIncrease, minRange, maxRange);
    }
}
