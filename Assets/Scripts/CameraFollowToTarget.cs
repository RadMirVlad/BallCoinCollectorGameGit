using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _targetOffset;

    private void LateUpdate()
    {
        transform.position = _target.position + _targetOffset;
    }
}
