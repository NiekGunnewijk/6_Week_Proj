using EventBus;
using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "GiveQuestEvent", menuName = "Dialogue/Event/GiveQuestEvent")]
    public class GiveQuestEvent : DialogueEvent
    {
        [SerializeField] private QuestController questController;
        [SerializeField] private Quest quest;
        public override void Execute()
        {
            Debug.Log("Executing GiveQuestEvent");
            QuestCreator.Instance.questController = questController;
            QuestCreator.Instance.CreateQuest(quest);
        }
    }
}