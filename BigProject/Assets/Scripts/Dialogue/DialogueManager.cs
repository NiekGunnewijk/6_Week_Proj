using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        private DialogueNode _currentNode;

        public void StartDialogue(DialogueNode dialogueNode)
        {
            if(dialogueNode.conditions.Length > 0 && ConditionsMet(dialogueNode)) 
                _currentNode = dialogueNode;
        }

        public void SelectChoice(int index)
        {
            _currentNode = _currentNode.choices[index].nextNode;
        }
        
        private bool ConditionsMet(DialogueNode node)
        {
            foreach (DialogueCondition condition in node.conditions)
            {
                if (condition == null)
                {
                    Debug.LogError("condition is null in dialogue node " + node.id);
                    break;
                }
                if (!condition.Evaluate())
                    return false;
            }

            return true;
        }
    }
}