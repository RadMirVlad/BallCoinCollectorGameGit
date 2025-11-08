using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }

    [SerializeField] private float _rollSpeed;
    [SerializeField] private GameManager _gameManager;

    private Rigidbody _rigidbody;

    private string _horizontalInputString = "Horizontal";
    private string _verticalInputString = "Vertical";

    private bool _isMovingForward;
    private bool _isMovingAside;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw(_verticalInputString);
        float horizontalInput = Input.GetAxisRaw(_horizontalInputString);

        if (verticalInput != 0)
        {
            VerticalInput = verticalInput;

            HorizontalInput = 0;

            _isMovingForward = true;
            _isMovingAside = false;
        }

        if (horizontalInput != 0)
        {
            HorizontalInput = horizontalInput;

            VerticalInput = 0;

            _isMovingForward = false;
            _isMovingAside = true;
        }

        if (verticalInput == 0 && horizontalInput == 0)
        {
            _isMovingForward = false;
            _isMovingAside = false;

            VerticalInput = 0;
            HorizontalInput = 0;
        }
    }

    public void Movement()
    {
        if (_isMovingForward)
        {
            _rigidbody.AddTorque(VerticalInput * _rollSpeed, 0, 0, ForceMode.VelocityChange);
        }

        if (_isMovingAside)
        {
            _rigidbody.AddTorque(0, 0, -HorizontalInput * _rollSpeed, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if (_gameManager.IsRunning)
        {
            Movement();
        }
    }
}
