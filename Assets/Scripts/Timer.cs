using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _maxTimerValue;

    private float _timer;
    private float _currentTimerValue;
    public bool IsUp { get; private set; } = false;

    private void Awake()
    {
        _currentTimerValue = _maxTimerValue;
    }

    public bool Tick()
    {
        _timer += Time.deltaTime;
        _currentTimerValue = _maxTimerValue - _timer;

        if (_currentTimerValue <= 0)
        {
            _currentTimerValue = 0;
            IsUp = true;
        }
        return IsUp;
    }

    public string GetCurrentTimerValue() => _currentTimerValue.ToString("0.00");
}
