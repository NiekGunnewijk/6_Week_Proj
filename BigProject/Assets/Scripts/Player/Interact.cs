using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


public class Interact : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float interactRange = 1;

    private void OnEnable()
    {
        playerInput.actions["Interact"].performed += CheckInteract;
    }

    private void OnDisable()
    {
        playerInput.actions["Interact"].performed -= CheckInteract;
    }

    private void CheckInteract(InputAction.CallbackContext context)
    {
        RaycastHit _hit;
        
        if (Physics.Raycast(this.transform.position,this.transform.forward, out _hit, interactRange))
        {
            IInteractable interactable;
            if (_hit.transform.TryGetComponent<IInteractable>(out interactable ))
            {
                interactable.Interact(this.gameObject);
            }
        }
    }




}
