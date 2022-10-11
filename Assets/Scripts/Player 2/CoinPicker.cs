using UnityEngine;
using TMPro;
using System.Collections;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoins;
    [SerializeField] private float increaseTime = 10;
    public static bool triggerParticles = false;
    private int i;
    private string[] coinPickupNames = { "CoinPickup1", "CoinPickup2", "CoinPickup3", "CoinPickup4", "CoinPickup5" };
    private float volume;
    private float pitch;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Coin")
        {
            CoinPickUpSound();
            triggerParticles = true;
            Timer2.triggerFadeOut = true;
            AddPoints();
            textCoins.text = CoinCounter.totalCoins.ToString();
            
            Destroy(other.gameObject);
        }
    }

    public void AddPoints()
    {
        CoinCounter.totalCoins += 1;
        StartCoroutine(TimeIncrease());
    }

    private void FixedUpdate()
    {
        textCoins.text = CoinCounter.totalCoins.ToString();
    }

    public void IncreaseTime()
    {
        StartCoroutine(TimeIncrease());
        triggerParticles = true;
    }

    IEnumerator TimeIncrease()
    {
        int i = 0;
        //play particle effect when time is increased
        for (i = 0; i < 10; i++)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime + (increaseTime / 10), 0, Timer.startingTime);
            yield return new WaitForSeconds(.03f);
        }
    }

    private void CoinPickUpSound()
    {
        i = Random.Range(0, 5);
        volume = Random.Range(0.8f, 1f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play(coinPickupNames[i], volume, pitch);
    }
}
