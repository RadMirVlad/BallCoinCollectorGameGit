using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _rollSpeed;

    [SerializeField] private Timer _timer;
    [SerializeField] private ChickenCollector _chickenCollector;

    private Rigidbody _rigidbody;

    private Jump _jump;

    private string _horizontalInputString = "Horizontal";
    private string _verticalInputString = "Vertical";

    private string _tagWallString = "Wall";
    private string _tagFloorString = "Floor";

    private bool _isMovingForward;
    private bool _isMovingAside;

    private bool _isGrounded;

    private bool _isLose;
    private bool _isWin;

    public bool IsOnWall { get; private set; }
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _jump = GetComponent<Jump>();
    }

    private void Update()
    {
        _isLose = _timer.IsLose;
        _isWin = _chickenCollector.IsCollected;

        _isGrounded = _jump.IsGrounded;

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

    private void FixedUpdate()
    {
        if (_isLose == false && _isWin == false)
        {
            Movement();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagWallString))
        {
            IsOnWall = true;
        }
        if (collision.gameObject.CompareTag(_tagFloorString))
        {
            IsOnWall = false;
        }
    }

    private void Movement()
    {
        if (_isGrounded == true)
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
    }
}
