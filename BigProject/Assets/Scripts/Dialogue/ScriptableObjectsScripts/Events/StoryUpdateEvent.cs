using System.Collections;
using System.Linq;
using Dialogue;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "StoryUpdateEvent", menuName = "Dialogue/Event/StoryUpdateEvent")]
public class StoryUpdateEvent : DialogueEvent
{
    public CharacterData characterData;
    public StoryNode storyNode;
    public override void Execute()
    {
        if (!characterData.storyNodes.Contains(storyNode))
        {
            ((IList)characterData.storyNodes).Add(storyNode);
        }
    }
}
