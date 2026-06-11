using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Condition/QuestCondition")]
    public class QuestCondition: DialogueCondition
    {
        public Quest quest;
        
        public override bool Evaluate()
        {
            if (quest != null)
            {
                return quest.completed;
            }
            return false;
        }
    }
}