using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string id;
    public string characterName;
    public int friendshipLevel;
    public StoryNode mainStory;
    public StoryNode[] storyNodes;
    public DialogueNode[] dialogouNodes;
    public DialogueNode currentDialogueNode;
    public int currentDialogue;

    private void OnDisable()
    {
        if (dialogouNodes.Length > 0)
        {
            currentDialogueNode = dialogouNodes[0];
        }
        friendshipLevel = 0;
    }
}
