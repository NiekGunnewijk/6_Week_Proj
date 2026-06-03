using Dialogue;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private DialogueManager _manager;
    [SerializeField]
    private DialogueUI _ui;
    [SerializeField]
    private CharacterData _testCharacter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _manager.StartDialogue(_testCharacter.story[0]);
        _ui.DisplayDialogue(_testCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
