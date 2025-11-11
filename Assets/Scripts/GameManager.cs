using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private BallJumper _ballJumper;
    [SerializeField] private CollisionDetector _collisionDetector;
    [SerializeField] private ChickenCollector _chickenCollector;

    [SerializeField] private MovementDetector _movementDetector;
    
    [SerializeField] private Timer _timer;

    [SerializeField] private List<Chicken> _chickenList;

    [SerializeField] private int _chickenValue;

    private int _listCount;
    private int _currentChickensCount;

    private bool _isStartTimer;

    private bool _isUp;
    private bool _isCollected;
    public bool IsWin { get; private set; } = false;
    public List<Chicken> ChickensList { get; private set; }

    private void Awake()
    {
        ChickensList = _chickenList;
        _listCount = _chickenList.Count;
    }

    private void Update()
    {
        _isStartTimer = _movementDetector.IsStartTimer;
        _isUp = _timer.IsUp;

        _isCollected = _chickenCollector.IsCollected;

        if (_isStartTimer)
        {
            _timer.Tick();
        }

        if (_isUp == false || IsWin == false)
        {
            if (_collisionDetector.IsOnWall == false && _collisionDetector.IsGrounded)
            {
                _ballMover.AllowRolling();
                _ballJumper.AllowJumping();
            }
            if (_collisionDetector.IsOnWall && _collisionDetector.IsGrounded == false)
            {
                _ballMover.AllowRolling();
                _ballJumper.DisableJumping();
            }
            if (_collisionDetector.IsOnWall == false && _collisionDetector.IsGrounded == false)
            {
                _ballMover.DisableRolling();
                _ballJumper.DisableJumping();
            }
        }

        if (_isUp || IsWin)
        {
            _ballMover.DisableRolling();
            _ballJumper.DisableJumping();
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

    public void AddChicken(int value) => _currentChickensCount += value;
    public int GetCollectedChickens() => _currentChickensCount;
}
