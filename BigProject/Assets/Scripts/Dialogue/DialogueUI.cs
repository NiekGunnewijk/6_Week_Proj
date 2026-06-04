using System;
using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject _dialogueUI;
    public TextMeshProUGUI SpeakerText;
    public TextMeshProUGUI DialogueText;
    
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;

    private void OnEnable()
    {
        EventBus<DialogueEndEvent>.OnEvent += DisableUI;
    }

    private void OnDisable()
    {
        EventBus<DialogueEndEvent>.OnEvent -= DisableUI;
    }

    public void DisplayDialogue(DialogueNode currentDialogueNode)
    {
        SpeakerText.text = currentDialogueNode.lines[currentDialogueNode.currentLine].character;
        DialogueText.text = currentDialogueNode.lines[currentDialogueNode.currentLine].text;
    }
    
    public void ShowChoices(DialogueNode currentNode)
    {
        DestroyButtons();
        foreach(DialogueChoice choice in currentNode.choices)
        {
            CreateButton(choice);
        }
    }

    private void CreateButton(DialogueChoice choice)
    {
        Button button =
            Instantiate(choiceButtonPrefab,
                choicesContainer);

        button.GetComponentInChildren<TextMeshProUGUI>()
            .text = choice.text;

        button.onClick.AddListener(() =>
        {
            DialogueManager.Instance
                .SelectChoice(choice);
            DestroyButtons();
        });
    }

    private void DestroyButtons()
    {
        for (int i = 0; i < choicesContainer.childCount; i++)
        {
            Destroy(choicesContainer.GetChild(i).gameObject);
        }
    }

    public void EnableUI()
    {
        _dialogueUI.SetActive(true);
    }
    private void DisableUI(DialogueEndEvent dialogueEndEvent)
    {
        _dialogueUI.SetActive(false);
    }
}
