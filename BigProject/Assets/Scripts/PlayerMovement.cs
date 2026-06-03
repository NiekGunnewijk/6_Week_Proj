
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _movementSpeed = 1f;

    private void Awake() =>
        _rb = GetComponent<Rigidbody>();

    private void OnEnable()
    {
        _playerInput.actions["Move"].performed += Move;
        _playerInput.actions["Move"].canceled += StopMove;

    }

    private void OnDisable()
    {
        _playerInput.actions["Move"].performed -= Move;
        _playerInput.actions["Move"].canceled -= StopMove;
    }


    private void Move(InputAction.CallbackContext context)
    {
        Vector3 newForward = context.ReadValue<Vector2>();
        transform.forward = new Vector3(newForward.x, 0, newForward.y);
        transform.Rotate(0, 45, 0);

        _rb.linearVelocity = transform.forward * _movementSpeed;
    }

    private void StopMove(InputAction.CallbackContext _) =>
        _rb.linearVelocity = Vector3.zero;





}
