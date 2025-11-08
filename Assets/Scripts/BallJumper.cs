using UnityEngine;

public class BallJumper : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    public bool IsOnWall { get; private set; }
    public bool IsJumping { get; private set; }

    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private string _tagFloorString = "Floor";
    private string _tagWallString = "Wall";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsOnWall == false)
        {
            if (IsGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }
            }
        }
        else if (IsOnWall)
        {
            OnGround();
        }
    }
    private void Jump()
    {
        IsGrounded = false;
        IsJumping = true;
    }
    private void OnGround()
    {
        IsGrounded = true;
        IsJumping = false;
    }

    private void FixedUpdate()
    {
        if (IsJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            IsGrounded = false;
            IsJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagFloorString))
        {
            IsGrounded = true;
            IsOnWall = false;
        }
        if (collision.gameObject.CompareTag(_tagWallString))
        {
            IsOnWall = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsOnWall)
        {
            if (IsGrounded)
            {
                IsJumping = false;
            }
        }
    }
}
