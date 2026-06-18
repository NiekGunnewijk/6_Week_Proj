using UnityEngine;

[CreateAssetMenu(fileName = "StoryNode", menuName = "Story/StoryNode")]
public class StoryNode : ScriptableObject
{
    [TextArea(10, 20)] 
    public string storyPart;
}
