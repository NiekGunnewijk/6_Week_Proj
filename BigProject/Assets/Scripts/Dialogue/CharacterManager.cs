using Dialogue;
using UnityEngine;

public class CharacterManager : MonoBehaviour, IInteractable
{
    public CharacterData characterData;

    public void Interact(GameObject gameObject)
    {
        Debug.Log("Interact");
        DialogueManager.Instance.StartDialogue(characterData.currentDialogueNode);
    }
}
