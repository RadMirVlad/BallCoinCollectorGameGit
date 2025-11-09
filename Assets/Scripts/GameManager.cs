using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsWin { get; private set; } = false;
    public bool IsAllowToRoll { get; private set; } = false;
    public bool IsAllowToJump { get; private set; } = false;
    public List<Chicken> ChickensList { get; private set; }

    [SerializeField] private BallMover _ballMover;
    [SerializeField] private BallJumper _ballJumper;
    [SerializeField] private MovementDetector _movementDetector;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private Timer _timer;

    [SerializeField] private ChickenCollector _chickenCollector;
    [SerializeField] private List<Chicken> _chickenList;

    [SerializeField] private int _chickenValue;

    private int _listCount;
    private int _currentChickensCount;

    private bool _isStartTimer;

    private bool _isLose;
    private bool _isCollected;

    private bool _isOnWall;
    private bool _isGrounded;
    private bool _isJumping;

    private void Awake()
    {
        ChickensList = _chickenList;
        _listCount = _chickenList.Count;
    }

    private void Update()
    {
        _isStartTimer = _movementDetector.IsStartTimer;
        _isLose = _timer.IsLose;

        _isJumping = _ballJumper.IsJumping;
        _isOnWall = _collisionDetector.IsOnWall;
        _isGrounded = _collisionDetector.IsGrounded;

        _isCollected = _chickenCollector.IsCollected;

        if (_isStartTimer)
        {
            _timer.TimeToCollect();
        }

        if (_isLose == false || IsWin == false)
        {
            IsAllowToRoll = true;
            IsAllowToJump = true;

            if (_isJumping)
            {
                StopMovement();
            }
            if (_isOnWall)
            {
                IsAllowToJump = false;
            }
            if (_isGrounded == false && _isOnWall == false)
            {
                StopMovement();
            }
        }
        
        if (_isLose || IsWin)
        {
            StopMovement();
        }

        if (_isCollected == true)
        {
            AddChicken(_chickenValue);

            if (_currentChickensCount == _listCount)
            {
                _chickenCollector.enabled = false;

                AddChicken(_chickenValue);

                IsWin = true;
            }
        }
    }
    private void StopMovement()
    {
        IsAllowToRoll = false;
        IsAllowToJump = false;
    }
    public void AddChicken(int value) => _currentChickensCount += value;
    public int GetCollectedChickens() => _currentChickensCount;
}
