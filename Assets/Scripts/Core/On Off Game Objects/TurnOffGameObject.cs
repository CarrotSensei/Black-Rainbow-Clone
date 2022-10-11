using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffGameObject : MonoBehaviour
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
        One.SetActive(false);
        Two.SetActive(false);
        Three.SetActive(false);
        Four.SetActive(false);
        Five.SetActive(false);
        Six.SetActive(false);
        Seven.SetActive(false);
        Eight.SetActive(false);
        Nine.SetActive(false);
        Ten.SetActive(false);
    }
}
