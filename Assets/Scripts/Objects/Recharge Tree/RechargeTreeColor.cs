using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTreeColor : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    Color m_NewColor;
    float m_Red, m_Blue, m_Green;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = Color.blue;
    }


    private void Update()
    {
        m_Red = RechargeTree.powerRemaining / RechargeTree.startingPower1;
        m_Green = RechargeTree.powerRemaining / RechargeTree.startingPower1;
        m_Blue = RechargeTree.powerRemaining / RechargeTree.startingPower1;
        m_NewColor = new Color(m_Red, m_Green, m_Blue);
        m_SpriteRenderer.color = m_NewColor;
    }

}
