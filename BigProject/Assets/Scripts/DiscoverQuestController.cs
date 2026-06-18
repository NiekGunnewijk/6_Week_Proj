using UnityEngine;
using EventBus;
public class DiscoverQuestController : QuestController
{
    public DiscoverQuest quest;

    private void Update()
    {
        Vector3 obj = Camera.main.WorldToViewportPoint(quest.DiscoverObject.transform.position);
        if (obj.x > 0 && obj.x < 1 && obj.y > 0 && obj.y < 1)
        {
            quest.completed = true;
            DisplayText();
        }
    }

    private void OnEnable()
    {
        questText.text = quest.questName + "\n" + quest.questDescription;
    }
    private void DisplayText()
    {
        questText.text = quest.questName + "\n" + quest.questDescription +" Completed";
    }
}
