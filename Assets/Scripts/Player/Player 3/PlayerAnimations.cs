using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private float horizontalInput;
    private Animator anim;
    public static bool canAttack;
    private bool facingRight = true;
    private float oldPos;
    private int i;
    private string[] swordSoundNames = { "SwordSlash1", "SwordSlash2" , "SwordSlash3" };
    private string[] bootFootStepsNames = { "BootFootStep0", "BootFootStep1", "BootFootStep2", "BootFootStep3", "BootFootStep4", "BootFootStep5", "BootFootStep6", "BootFootStep7", "BootFootStep8" };
    private float volume;
    private float pitch;
    private bool isGrounded;
    private bool spawnDust;
    private bool spawnDust2;
    private bool lastStep;
    private bool lands;
    private bool jumps;
    [SerializeField] private GameObject landDustEffect;
    [SerializeField] private GameObject jumpDustEffect;
    [SerializeField] private GameObject trailDustEffect;
    [SerializeField] private GameObject groundCheck;
    private float timeBtwTrail;
    private float timeBtwFootStep;
    private float startTimeBtwTrail;
    private float startTimeBtwFootStep;


    private void Start()
    {
        oldPos = transform.position.x;
        canAttack = true;
    }

    private void Awake()
    {
        //Grab reference for animator from game object
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //flip player
        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput > 0.01f && facingRight && canAttack == true)
        {
            Flip();
        }
        else if (horizontalInput < -0.01f && !facingRight && canAttack == true)
        {
            Flip();
        }

        if (oldPos == transform.position.x)
        {
            horizontalInput = 0;
        }
        oldPos = transform.position.x;


        //set animation parameters
        anim.SetBool("isMoving", horizontalInput != 0);
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack == true)
        {
            anim.SetTrigger("attack");

            //Random Sword Swing Sound Generator
            SwordSwingSound();

            StartCoroutine(WaitBeforeSwordSwing(0.4f));
        }


        if (TarodevController.PlayerController.isGrounded == true)
        {
            //land sound
            if (lands == true)
            {
                LandSound();
                lands = false;
            }
            //jump sound
            if (Input.GetKeyDown("space") && jumps == true)
            {
                JumpSound();
                jumps = false;
            }
            //particles
            spawnDust2 = true;
            if (spawnDust == true)
            {
                Instantiate(landDustEffect, groundCheck.transform.position, Quaternion.identity);
                spawnDust = false;
            }

            if (timeBtwTrail <= 0 && horizontalInput != 0)
            {
                Instantiate(trailDustEffect, groundCheck.transform.position, Quaternion.identity);
                startTimeBtwTrail = Random.Range(0.2f, 0.5f);
                timeBtwTrail = startTimeBtwTrail;
            }
            else
            {
                timeBtwTrail -= Time.deltaTime;
            }

            //Foot step sounds
            if (timeBtwFootStep <= 0 && horizontalInput != 0)
            {
                startTimeBtwFootStep = 0.2f;
                timeBtwFootStep = startTimeBtwFootStep;
                BootFootStepsSound();
            }
            else
            {
                timeBtwFootStep -= Time.deltaTime; 
            }
        }
        else
        {
            jumps = true;
            lands = true;
            spawnDust = true;
            if (spawnDust2 == true)
            {
                Instantiate(jumpDustEffect, groundCheck.transform.position, Quaternion.identity);
                spawnDust2 = false;
            }
        }

    }

    private void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }


    IEnumerator WaitBeforeSwordSwing(float time)
    {
        canAttack = false;
        yield return new WaitForSeconds(time);
        canAttack = true;
    }

    private void SwordSwingSound()
    {
        i = Random.Range(0, 3);
        volume = Random.Range(0.1f, 0.3f);
        pitch = Random.Range(1f, 4f);
        FindObjectOfType<AudioManager>().Play(swordSoundNames[i], volume, pitch);
    }


    private void BootFootStepsSound()
    {
        if (i == 8)
        {
            i = 0;
        }
        i++;
        volume = Random.Range(0.05f, 0.08f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play(bootFootStepsNames[i], volume, pitch);
    }

    private void LandSound()
    {
        if (TarodevController.PlayerController.Velocity1.y <= -60f)
        {
            volume = 0.6f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= -50f)
        {
            volume = 0.5f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= -40f)
        {
            volume = 0.4f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= -30f)
        {
            volume = 0.3f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= -20f)
        {
            volume = 0.2f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= -10f)
        {
            volume = 0.1f;
        }
        else if (TarodevController.PlayerController.Velocity1.y <= 0f)
        {
            volume = 0f;
        }

        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play("Land", volume, pitch);
    }

    private void JumpSound()
    {
        volume = Random.Range(0.8f, 0.8f);
        pitch = Random.Range(0.8f, 1f);
        FindObjectOfType<AudioManager>().Play("Jump", volume, pitch);
    }
}
