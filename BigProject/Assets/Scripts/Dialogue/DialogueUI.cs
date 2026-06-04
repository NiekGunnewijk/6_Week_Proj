using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public TextMeshProUGUI SpeakerText;
    public TextMeshProUGUI DialogueText;
    
    [SerializeField] private Transform choicesContainer;
    [SerializeField] private Button choiceButtonPrefab;
    
    public void DisplayDialogue(DialogueNode currentDialogueNode)
    {
        SpeakerText.text = currentDialogueNode.lines[currentDialogueNode.currentLine].character;
        DialogueText.text = currentDialogueNode.lines[currentDialogueNode.currentLine].text;
    }
    
    public void ShowChoices(DialogueNode currentNode)
    {
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
}
