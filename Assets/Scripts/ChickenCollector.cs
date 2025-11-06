using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollector : MonoBehaviour
{
    public int Chickens { get; private set; }

    [SerializeField] private List<Chicken> _chickensList;

    private int _listCount;
    public bool IsCollected { get; private set; } = false;

    private void Awake()
    {
        _listCount = _chickensList.Count;
    }
    public void AddChicken(int value)
    {
        Chickens += value;
    }

    public int WriteCollectedChickens()
    {
        return Chickens;
    }

    public int WriteCurrentChickensListCount()
    {
        return _listCount;
    }

    private void Update()
    {
        if (IsCollected == false)
        {
            if (Chickens == _listCount)
            {
                IsCollected = true;
            }
        }
    }
}
