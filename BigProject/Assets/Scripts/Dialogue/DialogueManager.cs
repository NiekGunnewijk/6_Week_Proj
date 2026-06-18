using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }
        
        [SerializeField] private PlayerInput _playerInput;
        private DialogueNode _currentNode;
        [SerializeField] private DialogueUI _ui;
        
        private void OnEnable()
        {
            _playerInput.actions["Next"].performed += NextLine;
            Instance = this;
        }

        private void OnDisable()
        {
            if(_playerInput != null) 
                _playerInput.actions["Next"].performed -= NextLine;
        }

        private void NextLine(InputAction.CallbackContext obj)
        {
            NextLine(_currentNode);
        }

        public void StartDialogue(DialogueNode dialogueNode)
        {
            if (dialogueNode.conditions.Length <= 0 || ConditionsMet(dialogueNode))
            {
                dialogueNode.StartDialogue();
                _currentNode = dialogueNode;
                _ui.DisplayDialogue(_currentNode);
                _ui.EnableUI();
            }
            else
            {
                StartDialogue(dialogueNode.conditionNotMetNode);
                Debug.Log("Dialogue conditions not met");
            }
        }

        public void SelectChoice(DialogueChoice dialogueChoice)
        {
            if (dialogueChoice.events.Length > 0)
            {
                foreach (var dialogueEvent in dialogueChoice.events)
                {
                    if (dialogueEvent != null)
                    {
                        dialogueEvent.Execute();
                        //Debug.Log(dialogueEvent.name);
                    }
                }
            }
            StartDialogue(dialogueChoice.nextNode);
        }

        public void NextLine(DialogueNode currentDialogueNode)
        {
            if (currentDialogueNode != null)
            {
                if (currentDialogueNode.currentLine >= currentDialogueNode.lines.Length - 1)
                {
                    if (_currentNode.choices.Length > 0)
                    {
                        _ui.ShowChoices(currentDialogueNode);
                    }
                    else
                    {
                        EventBus<DialogueEndEvent>.Publish(new DialogueEndEvent());
                        ExecuteEvents(currentDialogueNode);
                    }
                }
                else
                {
                    currentDialogueNode.currentLine++;
                    _ui.DisplayDialogue(currentDialogueNode);
                }
            }
        }
        
        private bool ConditionsMet(DialogueNode node)
        {
            foreach (DialogueCondition condition in node.conditions)
            {
                if (condition == null)
                {
                    Debug.LogError("condition is null in dialogue node " + node.id);
                    break;
                }
                if (!condition.Evaluate())
                    return false;
            }
            return true;
        }
        

        private void ExecuteEvents(DialogueNode node)
        {
            foreach (var dialogueEvent in node.events)
            {
                dialogueEvent.Execute();
            }
        }
    }
}