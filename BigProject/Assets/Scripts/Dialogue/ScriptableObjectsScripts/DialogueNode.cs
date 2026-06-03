using Dialogue;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/DialogueNode")]
public class DialogueNode : ScriptableObject
{
    public string id;
    
    [TextArea]
    public string text;
    
    public DialogueCondition[] conditions;
    
    public DialogueChoice[] choices;
}
