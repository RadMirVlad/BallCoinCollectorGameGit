using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool IsLose { get; private set; } = false;

    [SerializeField] private float _maxTimerValue;

    private float _timer;
    private float _currentTimerValue;

    private void Awake()
    {
        _currentTimerValue = _maxTimerValue;
    }

    public bool TimeToCollect()
    {
        _timer += Time.deltaTime;
        _currentTimerValue = _maxTimerValue - _timer;

        if (_currentTimerValue <= 0)
        {
            _currentTimerValue = 0;
            IsLose = true;
        }
        return IsLose;
    }

    public string GetCurrentTimerValue() => _currentTimerValue.ToString("0.00");
}
