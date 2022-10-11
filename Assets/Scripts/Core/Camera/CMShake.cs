using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMShake : MonoBehaviour
{
    [SerializeField] private Animator camAnim;

    public void CamShakeZoom()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
            camAnim.SetTrigger("shake1");
        else if (rand == 2)
            camAnim.SetTrigger("shake4");
    }

    public void CamShakeTilt()
    {
        int rand = Random.Range(1, 3);
        if (rand == 1)
            camAnim.SetTrigger("shake2");
        else if (rand == 2)
            camAnim.SetTrigger("shake3");
    }

    public void CamShakeTiltAndZoom()
    {
        int rand = Random.Range(1, 5);
        if (rand == 1)
            camAnim.SetTrigger("shake5");
        else if (rand == 2)
            camAnim.SetTrigger("shake6");
        else if (rand == 3)
            camAnim.SetTrigger("shake7");
        else if (rand == 4)
            camAnim.SetTrigger("shake8");
    }

    public void CamFocusOut1()
    {
        camAnim.SetBool("focousOut1", true);
    }

    public void CamFocusOutSnapBackToIdle1()
    {
        camAnim.SetBool("focousOut1", false);
    }
}
