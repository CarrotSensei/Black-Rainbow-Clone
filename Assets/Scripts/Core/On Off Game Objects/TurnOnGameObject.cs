using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGameObject : MonoBehaviour
{
    [SerializeField] private GameObject One;
    [SerializeField] private GameObject Two;
    [SerializeField] private GameObject Three;
    [SerializeField] private GameObject Four;
    [SerializeField] private GameObject Five;
    [SerializeField] private GameObject Six;
    [SerializeField] private GameObject Seven;
    [SerializeField] private GameObject Eight;
    [SerializeField] private GameObject Nine;
    [SerializeField] private GameObject Ten;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        One.SetActive(true);
        Two.SetActive(true);
        Three.SetActive(true);
        Four.SetActive(true);
        Five.SetActive(true);
        Six.SetActive(true);
        Seven.SetActive(true);
        Eight.SetActive(true);
        Nine.SetActive(true);
        Ten.SetActive(true);
    }
}
