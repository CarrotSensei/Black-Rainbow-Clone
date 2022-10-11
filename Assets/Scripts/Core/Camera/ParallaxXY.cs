using UnityEngine;

public class ParallaxXY : MonoBehaviour
{
    private float lengthx;
    private float lengthy;
    private float startposx;
    private float startposy;
    [SerializeField] private GameObject cam;
    [SerializeField] private float parallaxEffect;


    void Start()
    {
        startposx = transform.position.x;
        startposy = transform.position.y;
        lengthx = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthy = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    void Update()
    {
        float tempx = (cam.transform.position.x * (1 - parallaxEffect));
        float tempy = (cam.transform.position.y * (1 - parallaxEffect));
        float distx = (cam.transform.position.x * parallaxEffect);
        float disty = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startposx + distx, startposy + disty, transform.position.z);

        if (tempx > startposx + lengthx)
        {
            startposx += lengthx;
        }
        else if (tempx < startposx - lengthx)
        {
            startposx -= lengthx;
        }
        
        if (tempy > startposy + lengthy)
        {
            startposy += lengthy;
        }
        else if (tempy < startposy - lengthy)
        {
            startposy -= lengthy;
        }
        
    }
}