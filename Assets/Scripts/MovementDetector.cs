using UnityEngine;

public class MovementDetector : MonoBehaviour
{

    [SerializeField] private Transform _ball;

    private Vector3 _startBallPosition;

    private bool _isMoved = false;
    public bool IsStartTimer { get; private set; } = false;

    private void Awake()
    {
        _startBallPosition = _ball.position;
    }

    private void Update()
    {
        if (_isMoved == false)
        {
            if (_ball.position != _startBallPosition)
            {
                IsStartTimer = true;

                _isMoved = true;

                Debug.Log("ќтсчЄт пошЄл.");
            }
        }
    }
}
