using EventBus;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "GiveQuestEvent", menuName = "Dialogue/Event/GiveQuestEvent")]
    public class GiveQuestEvent : DialogueEvent
    {
        public Quest quest;
        public override void Execute()
        {
            Debug.Log("Executing GiveQuestEvent");
            QuestCreator.Instance.CreateQuest(quest);
        }
    }
}