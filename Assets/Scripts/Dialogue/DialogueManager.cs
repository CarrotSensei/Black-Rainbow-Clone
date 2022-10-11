using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManager instance;

    private int numberOfChoices;

    public static bool canPressF;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        canPressF = false;

        //get all of the choices text
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        //Debug.Log();
        //return right away if dialogue isn't playing
        if(!dialogueIsPlaying)
        {
            return;
        }

        //handle continuing to the next line in the dialogue when submit is pressed
        if (Input.GetKeyDown("f") && numberOfChoices == 0 && canPressF == true|| Input.GetKeyDown(KeyCode.Mouse0) && numberOfChoices == 0)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        //Timer.pauseTimer = true;
        PlayerAnimations.canAttack = false;
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        //Timer.pauseTimer = false;
        PlayerAnimations.canAttack = true;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        canPressF = false;
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            //set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            //display choices, if any, for this dialogue line
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        numberOfChoices = currentChoices.Count;

        //deffensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: " + currentChoices.Count);
        }

        int index = 0;
        //enable and initate the choices up to the amount of choices for this line of dialogue
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        //go through the remaining choices the Ui supports and make sure they're hidden
        for(int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //Enabled automatically has the first choice selected. I want to choose with the cursor so i disabled it.
        //StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        //event system requires  we clear it first, then wait for at least one frame befor we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
}
