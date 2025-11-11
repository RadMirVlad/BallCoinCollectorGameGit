using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] CollisionDetector _collisionDetector;

    [SerializeField] private float _rollSpeed;

    private Rigidbody _rigidbody;

    private string _horizontalInputString = "Horizontal";
    private string _verticalInputString = "Vertical";

    private bool _isMovingForward;
    private bool _isMovingAside;
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }
    public bool IsRolling { get; private set; } = false;
    public bool IsAllowToRoll { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw(_verticalInputString);
        float horizontalInput = Input.GetAxisRaw(_horizontalInputString);

        if (IsAllowToRoll)
        {
            if (verticalInput != 0)
            {
                VerticalInput = verticalInput;

                HorizontalInput = 0;

                _isMovingForward = true;
                _isMovingAside = false;

                IsRolling = true;
            }

            if (horizontalInput != 0)
            {
                HorizontalInput = horizontalInput;

                VerticalInput = 0;

                _isMovingForward = false;
                _isMovingAside = true;

                IsRolling = true;
            }

            if (verticalInput == 0 && horizontalInput == 0)
            {
                _isMovingForward = false;
                _isMovingAside = false;

                VerticalInput = 0;
                HorizontalInput = 0;

                IsRolling = false;
            }
        }
        IsRolling = false;
    }

    private void FixedUpdate()
    {
        if (IsAllowToRoll)
            Movement();
    }
    private void Movement()
    {
        if (_isMovingForward)
            _rigidbody.AddTorque(VerticalInput * _rollSpeed, 0, 0, ForceMode.VelocityChange);

        if (_isMovingAside)
            _rigidbody.AddTorque(0, 0, -HorizontalInput * _rollSpeed, ForceMode.VelocityChange);
    }

    public void DisableRolling() => IsAllowToRoll = false;
    public void AllowRolling() => IsAllowToRoll = true;
}
