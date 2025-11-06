using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private MovementDetector _movementDetector;

    private bool _isRun;
    public bool IsLose { get; private set; } = false;

    [SerializeField] private float _maxTimerValue;
    private float _timer;
    private float _currentTimerValue;

    private void Awake()
    {
        _currentTimerValue = _maxTimerValue;
    }

    private void Update()
    {
        _isRun = _movementDetector.IsRun;

        if(_isRun)
        {
            _timer += Time.deltaTime;
            _currentTimerValue = _maxTimerValue - _timer;

            if(_currentTimerValue <= 0)
            {
                _currentTimerValue = 0;
                IsLose = true;
            }
        }
    }

    public string WriteCurrentTimerValue()
    {
        return _currentTimerValue.ToString("0.00");
    }
}
