using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsLose { get; private set; } = false;

    [SerializeField] private BallMover _ballMover;
    [SerializeField] private BallJumper _ballJumper;
    [SerializeField] private MovementDetector _movementDetector;
    [SerializeField] private Timer _timer;
    [SerializeField] private ChickenCollector _chickenCollector;

    private bool _isLose;
    private bool _isWin;
    private bool _isRun;
    private bool _isGrounded;
    public bool IsRunning { get; private set; } = false;

    private void Update()
    {
        _isRun = _movementDetector.IsRun;
        _isLose = _timer.IsLose;
        _isWin = _chickenCollector.IsCollected;
        _isGrounded = _ballJumper.IsGrounded;

        if (_isRun)
        {
            _timer.TimeToCollect();
        }

        if(IsRunning ==false)
        {
            if (_isLose == false && _isWin == false)
            {
                if (_isGrounded)
                {
                    IsRunning = true;
                }
            }
        }
    }
}
