using UnityEngine;

public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private CollisionDetector _collisionDetector;

    private Rigidbody _rigidbody;
    public bool IsJumping { get; private set; } = false;
    public bool IsAllowToJump { get; private set; } = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsAllowToJump)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (IsJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            IsJumping = false;
        }
    }

    public void DisableJumping()
    {
        IsAllowToJump = false;
    }
    public void AllowJumping()
    {
        IsAllowToJump = true;
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
        }
    }
}
