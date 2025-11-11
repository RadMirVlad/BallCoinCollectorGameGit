using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleWritter : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameManager _gameManager;

    private string _timerTitleString = "Осталось времени на сбор грудок: ";
    private string _timerTitleEndString = " секунд.";

    private string _chickensCollectedString = "Грудок собрано: ";
    private string _chickensCollectedEndString = " из ";

    private string _loseMessage = "Вы проиграли.";
    private string _winMessage = "Вы собрали все грудки.\nУра!";

    private bool _isWin = false;
    private bool _isDone = false;

    private void Update()
    {
        if (_isDone == false)
        {
            _isWin = _gameManager.IsWin;

            if (_timer.IsUp == false && _gameManager.IsWin == false)
            {
                Debug.Log(_chickensCollectedString + _gameManager.GetCollectedChickens() + _chickensCollectedEndString + _gameManager.ChickensList.Count + "\n"
                + _timerTitleString + _timer.GetCurrentTimerValue() + _timerTitleEndString);
            }
            if (_isWin || _timer.IsUp)
            {
                if (_timer.IsUp)
                {
                    Debug.Log(_loseMessage);
                    _isDone = true;
                }
                if (_gameManager.IsWin)
                {
                    Debug.Log(_winMessage);
                    _isDone = true;
                }
            }
        }
    }
}
