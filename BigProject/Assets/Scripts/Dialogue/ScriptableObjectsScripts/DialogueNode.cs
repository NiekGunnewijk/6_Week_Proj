using System;
using Dialogue;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string id;

    public int currentLine = 0;
    
    public DialogueLine[] lines;
    
    public DialogueCondition[] conditions;
    
    public DialogueChoice[] choices;

    private void OnEnable()
    {
        currentLine = 0;
    }

    public void StartDialogue()
    {
        currentLine = 0;
    }
}
