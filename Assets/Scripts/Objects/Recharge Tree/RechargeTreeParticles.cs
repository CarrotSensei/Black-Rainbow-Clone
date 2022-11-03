using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTreeParticles : MonoBehaviour
{
    private ParticleSystem ps;
    [SerializeField] private GameObject player;
    [SerializeField] private float maxOuterDistance = 8f;
    [Header("if valueSlider == 1 then whole maxOuterDistance is center \nif valueSlider == 0 then center of maxOuterDistance is center")]
    [Range(0f, 1f)]
    [SerializeField] private float valueSlider = 0.6f;

    private float alphaKey1 = 0f;
    private float alphaKey2 = 1f;
    private float alphaKey3 = 1f;
    private float alphaKey4 = 0f;
    private float value = 0f;
    

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        var emission = ps.emission;
        emission.rateOverTime = RechargeTree.powerRemaining / 2;

        var col = ps.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();

        //if outside circle make particles alpha = 0
        if(Vector2.Distance(transform.position, player.transform.position) > maxOuterDistance)
        {
            alphaKey2 = 0f;
            alphaKey3 = 0f;
        }
        //else gradually make alpha higher the closer towards the center area you are (value slider decides where the center area is)
        else
        {
            value = Mathf.Abs((Vector2.Distance(transform.position, player.transform.position) / maxOuterDistance) - 1);
            if (value > valueSlider)
            {
                alphaKey2 = 1f;
                alphaKey3 = 1f;
            }
            else
            {
                alphaKey2 = value / valueSlider;
                alphaKey3 = value / valueSlider;
            }
        }

        grad.SetKeys(
            new GradientColorKey[] {    new GradientColorKey(Color.white, 0.0f),
                                        new GradientColorKey(Color.white, 1.0f)
                                    },
            new GradientAlphaKey[] {
                                        new GradientAlphaKey(alphaKey1, 0.0f),
                                        new GradientAlphaKey(alphaKey2, 0.1f),
                                        new GradientAlphaKey(alphaKey3, 0.5f),
                                        new GradientAlphaKey(alphaKey4, 1.0f)
                                    }
                     );

        col.color = grad;
    }

}
