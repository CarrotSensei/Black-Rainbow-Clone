using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoStuffExample : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color charmanderColor = Color.red;
    [SerializeField] private Color bulbasorColor = Color.green;
    [SerializeField] private Color squirtleColor = Color.blue;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        string pokemonName = ((Ink.Runtime.StringValue) DialogueManager.GetInstance().GetVariableState("pokemon_name")).value;

        switch (pokemonName)
        {
            case "":
                spriteRenderer.color = defaultColor;
                break;
            case "Charmander":
                spriteRenderer.color = charmanderColor;
                break;
            case "Bulbasor":
                spriteRenderer.color = bulbasorColor;
                break;
            case "Squirtle":
                spriteRenderer.color = squirtleColor;
                break;
            default:
                Debug.LogWarning("Pokemon name not handled by switch statement: " + pokemonName);
                break;
        }
    }
}
