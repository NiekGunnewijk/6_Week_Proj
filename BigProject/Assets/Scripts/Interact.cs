using UnityEngine;
using UnityEngine.InputSystem;


public class Interact : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float InteractRange = 1;

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += CheckInteract;
    }

    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= CheckInteract;
    }

    private void CheckInteract(InputAction.CallbackContext context)
    {
        RaycastHit _hit;
        if (Physics.Raycast(this.transform.position,this.transform.forward, out _hit, InteractRange))
        {
            IInteractable interactable;
            if (_hit.transform.TryGetComponent<IInteractable>(out interactable ))
            {
                interactable.Interact(this.gameObject);
            }
        }
    }




}
