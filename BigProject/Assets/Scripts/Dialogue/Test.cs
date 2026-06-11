using Dialogue;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueManager _manager;
    [SerializeField] private CharacterData _testCharacter;

    public void Interact(GameObject gameObject)
    {
        Debug.Log("Interact");
        DialogueManager.Instance.StartDialogue(_testCharacter.story[0]);
    }
}
