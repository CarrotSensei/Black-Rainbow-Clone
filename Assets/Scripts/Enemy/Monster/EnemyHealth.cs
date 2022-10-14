using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private GameObject enemyPatrol;
    [SerializeField] private GameObject bloodSpatterParticleEffect;
    [Header("Sounds")]
    [SerializeField] private string deathSound;
    [SerializeField] private string hurtSound;
    [Header("Time")]
    [SerializeField] private CoinPicker timeIncrease;

    private float volume;
    private float pitch;


    private CMShake cm;

    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CMShake>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "PlayerSword")
        {
            DealDamageToEnemy(1);
        }
    }

    private void Update()
    {
        if (health <=0)
        {
            EnemyDeathSound();
            Instantiate(bloodSpatterParticleEffect, transform.position, Quaternion.identity);
            timeIncrease.IncreaseTime();
            cm.CamShakeZoom();
            Destroy(gameObject);
            Destroy(enemyPatrol);
        }
    }

    public void DealDamageToEnemy(float damage)
    {   
        health = health - damage;
        if (health >= 1)
        {
            EnemyHurtSound();
        }
    }

    private void EnemyHurtSound()
    {
        volume = Random.Range(0.6f, 0.8f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play(hurtSound, volume, pitch);
    }

    private void EnemyDeathSound()
    {
        volume = Random.Range(0.6f, 0.8f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play(deathSound, volume, pitch);
    }
}
