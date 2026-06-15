using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string id;
    public string characterName;
    public int friendshipLevel;
    public DialogueNode[] story;
    public DialogueNode currentDialogueNode;
    public int currentDialogue;

    private void OnDisable()
    {
        if (story != null)
        {
            currentDialogueNode = story[0];
            friendshipLevel = 0;
        }
    }
}
