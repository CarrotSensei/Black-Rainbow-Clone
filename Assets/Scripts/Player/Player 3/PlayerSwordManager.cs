using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordManager : MonoBehaviour
{
    [SerializeField] private BoxCollider2D playerSword;

    private void Start()
    {
        playerSword.enabled = false;
    }

    private void EnableGameObject()
    {
        playerSword.enabled = true;
    }

    private void DisableGameObject()
    {
        playerSword.enabled = false;
    }
}
