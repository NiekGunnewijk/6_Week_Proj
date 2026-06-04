using Dialogue;
using UnityEngine;

public class Test : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueManager _manager;
    [SerializeField] private CharacterData _testCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject gameObject)
    {
        Debug.Log("Interact");
        DialogueManager.Instance.StartDialogue(_testCharacter.story[0]);
    }
}
