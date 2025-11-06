using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDetector : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    private Vector3 _startBallPosition;

    private bool _isMoving = false;
    public bool IsRun { get; private set; } = false;

    private void Awake()
    {
        _startBallPosition = _ball.position;
    }

    private void Update()
    {
        if (_isMoving == false)
        {
            if (_ball.position != _startBallPosition)
            {
                IsRun = true;

                _isMoving = true;

                Debug.Log("ќтсчЄт пошЄл.");
            }
        }
    }
}
