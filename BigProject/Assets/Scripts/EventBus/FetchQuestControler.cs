using TMPro;
using UnityEngine;

namespace EventBus
{
    /// <summary>
    /// This verson of quest controller subscribes to the event bus's ZombieKilledEvent,
    /// it doesn't know who were the publishers of this event
    /// </summary>
    public class FetchQuestController : QuestController
    {
        public FetchQuest fetchQuest;
        // Start is called before the first frame update
        void Start()
        {
            
            
        }
    
        private void DisplayText(PickUpEvent pickUpEvent)
        {
            if (pickUpEvent.Item == fetchQuest.item)
            {
                fetchQuest.currentValue++;
                questText.text = fetchQuest.questName + "\n"+  fetchQuest.questDescription + " " + fetchQuest.item.name + " " 
                                 + fetchQuest.currentValue + "/" + fetchQuest.questAmount;
                if (fetchQuest.currentValue >= fetchQuest.questAmount)
                {
                    fetchQuest.completed = true;
                    questText.text = fetchQuest.questName + "\n" + fetchQuest.questDescription 
                                     + " " + fetchQuest.item.name + " Completed";
                }
            }
        }
    
        private void OnEnable()
        {
            fetchQuest = (FetchQuest)quest;
            questText.text = fetchQuest.questName + "\n"+  fetchQuest.questDescription +  " " +fetchQuest.item.name + " " + fetchQuest.currentValue + "/" + fetchQuest.questAmount;
            
            EventBus<PickUpEvent>.OnEvent += DisplayText;
        }

        private void OnDisable()
        {
            EventBus<PickUpEvent>.OnEvent -= DisplayText;
        }
    }
}
