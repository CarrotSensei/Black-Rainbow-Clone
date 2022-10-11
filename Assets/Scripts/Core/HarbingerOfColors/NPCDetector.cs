using UnityEngine;

public class NPCDetector : MonoBehaviour
{
    [SerializeField] private float scaleIncrease = 0.1f;
    [SerializeField] private float minRange = 0f;
    [SerializeField] private float maxRange = 50f;
    public static float localScale;
    public static bool npcInRange = false;

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
    
    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "NPCVT" && localScale != 0)
        {
            npcInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "NPCVT")
        {
            npcInRange = false;
        }
    }

    public void ExpandScale()
    {
        transform.localScale = new Vector2(Mathf.Clamp(transform.localScale.x + scaleIncrease, minRange, maxRange), Mathf.Clamp(transform.localScale.y + scaleIncrease, minRange, maxRange));
        localScale = transform.localScale.x;
    }

    public void ShrinkScale()
    {
        transform.localScale = new Vector2(Mathf.Clamp(transform.localScale.x - scaleIncrease, minRange, maxRange), Mathf.Clamp(transform.localScale.y - scaleIncrease, minRange, maxRange));
        localScale = transform.localScale.x;
        if (transform.localScale.x == 0)
        {
            npcInRange = false;
        }
    }
}
