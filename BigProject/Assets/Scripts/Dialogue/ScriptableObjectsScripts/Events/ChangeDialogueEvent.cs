using Dialogue;
using UnityEngine;

[CreateAssetMenu(fileName = "ChangeDialogueEvent", menuName = "Dialogue/Event/ChangeDialogueEvent")]
public class ChangeDialogueEvent : DialogueEvent
{
    public CharacterData characterData;
    public DialogueNode dialogueNode;
    public override void Execute()
    {
        characterData.currentDialogueNode = dialogueNode;
    }
}
