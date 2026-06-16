using System;
using Dialogue;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterManager : MonoBehaviour, IInteractable
{
    public CharacterData characterData;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private CharacterMovement characterMovement;

    private void Start()
    {
        characterMovement = GetComponent<CharacterMovement>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Interact(GameObject gameObject)
    {
        Debug.Log("Interact");
        agent.enabled = false;
        characterMovement.enabled = false;
        DialogueManager.Instance.StartDialogue(characterData.currentDialogueNode);
    }

    private void ActivateAgent(DialogueEndEvent dialogueEndEvent)
    {
        agent.enabled = true;
        characterMovement.enabled = true;
    }

    private void OnEnable()
    {
        EventBus<DialogueEndEvent>.OnEvent += ActivateAgent;
    }

    private void OnDisable()
    {
        EventBus<DialogueEndEvent>.OnEvent -= ActivateAgent;
    }
}
