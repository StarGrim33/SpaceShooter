using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxWidth;

    private Vector2 _moveDirection = Vector2.zero;
    private PlayerInput _playerInput;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
        _playerInput.Player.Move.performed += OnMovementPerformed;
        _playerInput.Player.Move.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
        _playerInput.Player.Move.performed -= OnMovementPerformed;
        _playerInput.Player.Move.canceled -= OnMovementCancelled;
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, _minWidth, _maxWidth);
        position.y = Mathf.Clamp(position.y, _minHeight, _maxHeight);
        transform.position = position;

        _rb.velocity = _moveDirection * (_speed * Time.deltaTime);
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveDirection = value.ReadValue<Vector2>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        _moveDirection = Vector2.zero;
    }
}
