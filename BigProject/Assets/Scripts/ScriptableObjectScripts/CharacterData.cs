using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public string id;
    public string characterName;
    public int friendshipLevel;
    public DialogueNode[] story;
}
