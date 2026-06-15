namespace Dialogue
{
    [System.Serializable]
    public class DialogueChoice
    {
        public string text;
        
        public DialogueNode nextNode;
        
        public DialogueCondition[] conditions;
        
        public DialogueEvent[] events;
    }
}