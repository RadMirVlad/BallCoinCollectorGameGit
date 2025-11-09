using UnityEngine;

public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private GameManager _gameManager;

    private Rigidbody _rigidbody;
    public bool IsJumping { get; private set; } = false;
    public bool IsJumped { get; private set; } = false;

    private bool _isAllowToJump;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _isAllowToJump = _gameManager.IsAllowToJump;
        
        if (_isAllowToJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                IsJumping = true;
            }
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
}
