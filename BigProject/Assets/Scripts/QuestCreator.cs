using EventBus;
using TMPro;
using UnityEngine;

public class QuestCreator : MonoBehaviour
{
    public static QuestCreator Instance;
    [SerializeField] private Transform questContainer;
    [SerializeField] private TextMeshProUGUI questText;
    public QuestController questController;
    public void Awake()
    {
        Instance = this;
    }
    

    public void CreateQuest(Quest quest)
    {
        TextMeshProUGUI text = Instantiate(questText, questContainer);
        questController.questText = text;
        questController.quest = quest;
        Instantiate(questController, questContainer);
    }
}
