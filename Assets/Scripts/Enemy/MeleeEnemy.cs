using UnityEngine;
using System.Collections;

public class MeleeEnemy : MonoBehaviour
{
    [Header ("Attack Parameters")]
    [SerializeField] private float atackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float decreaseTime = 10;

    [Header ("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Sounds")]
    [SerializeField] private AudioClip attackSound;

    //references
    private Animator anim;
    private Health playerHealth;
    private EnemyPatrol enemyPatrol;

    private int i;
    private string[] PlayerHitNames = { "PlayerHit1", "PlayerHit2", "PlayerHit3", "PlayerHit4" };
    private float volume;
    private float pitch;

    private CMShake cm;
    private void Start()
    {
        cm = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CMShake>();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight.
        if (PlayerInsight() && Timer.currentTime !=0)
        {
            if (cooldownTimer >= atackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("attack");
                //SoundManager.instance.PlaySound(attackSound);
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInsight();
    }

    private bool PlayerInsight()
    {
        if (Timer.currentTime != 0)
        {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 
                        0, Vector2.left, 0, playerLayer);

            if (hit.collider != null)
                playerHealth = hit.transform.GetComponent<Health>();

            return hit.collider != null;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        //if player still in range damage him
        if (PlayerInsight())
        {
            //Timer.currentTime = Timer.currentTime - 1f;
            StartCoroutine(TimeDecrease());
            PlayerHitSound();
            int rand = Random.Range(1, 4);
            if (rand == 1)
                cm.CamShakeTilt();
            else if (rand == 2 || rand == 3)
                cm.CamShakeTiltAndZoom();
            
        }
    }

    IEnumerator TimeDecrease()
    {
        int i = 0;
        //play particle effect when time is increased
        for (i = 0; i < 10; i++)
        {
            Timer.currentTime = Mathf.Clamp(Timer.currentTime - (decreaseTime / 10), 0, Timer.startingTime);
            yield return new WaitForSeconds(.03f);
        }
    }

    private void PlayerHitSound()
    {
        i = Random.Range(0, 4);
        volume = Random.Range(0.6f, 0.8f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play(PlayerHitNames[i], volume, pitch);
    }
}
