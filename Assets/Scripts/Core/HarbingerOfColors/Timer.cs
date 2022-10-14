using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime;
    public static float timeMultiplier = 1;
    public static float startingTime = 100f;
    public static bool pauseTimer = false;
    public static bool timeIsZero = false;

    [SerializeField] private float timeMultiplierDiv = 50;
    [SerializeField] private TextMeshProUGUI countdownText;

    [SerializeField] private ChangeScale shrinkScale;
    [SerializeField] private ChangeLightRange shrinkLightRange;
    [SerializeField] private ChangeParticleRadius shrinkParticleRadius;
    [SerializeField] private NPCDetector shrinkScale1;


    void Start()
    {
        currentTime = 1;
    }
    void FixedUpdate()
    {
        if (pauseTimer == false)
        {
            timeIsZero = false; ;
            timeMultiplier = ChangeScale.localScale / timeMultiplierDiv;
            currentTime = currentTime - timeMultiplier * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                timeIsZero = true;
                CloseHarbingerOfColors();
            }
        }
    }


    private void CloseHarbingerOfColors()
    {
        shrinkScale.ShrinkScale();
        shrinkLightRange.ShrinkLightRange();
        shrinkParticleRadius.ShrinkParticleRadius();
        shrinkScale1.ShrinkScale();
    }

}