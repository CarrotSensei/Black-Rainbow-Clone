using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [Header("visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerinRange;

    [SerializeField] private GameObject visualTrigger;


    private void Awake()
    {
        playerinRange = false;
        visualCue.SetActive(false);
        visualTrigger.SetActive(false);
    }

    private void Update()
    {
        
        if(playerinRange && !DialogueManager.GetInstance().dialogueIsPlaying && NPCDetector.npcInRange == true)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown("f"))
            {
                StartCoroutine(CanPressFAfterOneFrame());
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerinRange = true;
            visualTrigger.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerinRange = false;
            visualTrigger.SetActive(false);
        }
    }

    IEnumerator CanPressFAfterOneFrame()
    {
        yield return new WaitForEndOfFrame();
        DialogueManager.canPressF = true;
    }

}
