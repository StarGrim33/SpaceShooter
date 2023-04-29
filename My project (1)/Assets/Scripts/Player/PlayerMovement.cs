using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _minHeight;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxWidth;
    [SerializeField] private Camera _mainCamera;

    public float MaxWidth => _minHeight;

    public float Speed
    {
        get { return _speed; }
        private set { _speed = value; }
    }

    private float _originalSpeed;
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

        //Vector3 viewportPosition = _mainCamera.WorldToViewportPoint(position);

        //// Проверяем, выходит ли игрок за пределы экрана
        //if (viewportPosition.x < 0.0f)
        //{
        //    position.x = _minWidth;
        //}
        //else if (viewportPosition.x > 1f)
        //{
        //    position.x = _maxWidth;
        //}

        //if (viewportPosition.y < 0f)
        //{
        //    position.y = _minHeight;
        //}
        //else if (viewportPosition.y > 1f)
        //{
        //    position.y = _maxHeight;
        //}

        //transform.position = position;
        //_rb.velocity = _moveDirection * (_speed * Time.deltaTime);

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

    public void ChangeSpeed(float value, float duration)
    {
        StartCoroutine(SpeedBoost(value, duration));
    }

    private IEnumerator SpeedBoost(float value, float duration)
    {
        var waitForSeconds = new WaitForSeconds(duration);

        Speed += value;

        yield return waitForSeconds;

        Speed -= value;
    }
}
