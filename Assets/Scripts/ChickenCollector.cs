using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCollector : MonoBehaviour
{
    public bool IsCollected { get; private set; } = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Chicken>())
        {
            IsCollected = true;
            other.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        IsCollected = false;
    }
}
