using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    [SerializeField] private float scaleIncrease = 0.1f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRange = 50f;
    public static float localScale;

    [Header("volume = localScale[0,50] / volumeAdjustment")]
    [SerializeField] private float volumeAdjustment;
    AudioSource m_MyAudioSource;

    /*
    private void FixedUpdate()
    {
        if(Input.GetKey("e") && Timer.timeIsZero == false)
        {
            ExpandScale();
        }
        if (Input.GetKey("q") && Timer.timeIsZero == false)
        {
            ShrinkScale();
        }
    }*/

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

    private void Start()
    {
        m_MyAudioSource = GetComponent<AudioSource>();
        m_MyAudioSource.Play();
    }


    public void Update()
    {
        m_MyAudioSource.volume = localScale / volumeAdjustment;
    }
}
