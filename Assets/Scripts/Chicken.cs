using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [SerializeField] ChickenCollector _chickensCollector;

    [SerializeField] private int _chickenValue;

    private string _tagPlayerString = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(_tagPlayerString))
        {
            _chickensCollector.AddChicken(_chickenValue);

            gameObject.SetActive(false);
        }
    }
}
