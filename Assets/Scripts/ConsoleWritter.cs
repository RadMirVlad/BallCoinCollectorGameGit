using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleWritter : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ChickenCollector _chickenCollector;

    private string _timerTitleString = "Осталось времени на сбор грудок: ";
    private string _timerTitleEndString = " секунд.";

    private string _chickensCollectedString = "Грудок собрано: ";
    private string _chickensCollectedEndString = " из ";

    private string _loseMessage = "Вы проиграли.";
    private string _winMessage = "Вы собрали все грудки.\nУра!";


    private void Update()
    {
        if (_timer.IsLose == false && _chickenCollector.IsCollected == false)
        {
            Debug.Log(_chickensCollectedString + _chickenCollector.WriteCollectedChickens() + _chickensCollectedEndString + _chickenCollector.GetCurrentChickensCount() + "\n"
            + _timerTitleString + _timer.WriteCurrentTimerValue() + _timerTitleEndString);
        }

        if (_timer.IsLose)
        {
            Debug.Log(_loseMessage);
        }

        if (_chickenCollector.IsCollected)
        {
            Debug.Log(_winMessage);
        }
    }
}
