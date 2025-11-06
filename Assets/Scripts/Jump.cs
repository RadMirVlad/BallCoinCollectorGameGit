using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Move _move;

    [SerializeField] private float _jumpForce;

    private Rigidbody _rigidbody;

    private bool _isJumping;

    public bool IsGrounded { get; private set; }

    private string _tagFloorString = "Floor";

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _move = GetComponent<Move>();
    }

    private void Update()
    {
        if (_move.IsOnWall == false)
        {
            if (IsGrounded == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    IsGrounded = false;
                    _isJumping = true;
                }
            }
        }
        else if (_move.IsOnWall)
        {
            IsGrounded = true;
            _isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumping)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            IsGrounded = false;
            _isJumping = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(_tagFloorString))
        {
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_move.IsOnWall)
        {
            if (IsGrounded)
            {
                _isJumping = false;
            }
        }
    }
}
