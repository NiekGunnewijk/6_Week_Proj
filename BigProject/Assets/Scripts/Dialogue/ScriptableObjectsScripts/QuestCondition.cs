using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Condition/QuestCondition")]
    public class QuestCondition: DialogueCondition
    {
        public string questId;
        
        public override bool Evaluate()
        {
            throw new System.NotImplementedException();
        }
    }
}