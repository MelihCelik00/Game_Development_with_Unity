using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField] 
    private float _smoothness;

    [SerializeField]
    private Vector3 _offset;
    
    private void FixedUpdate()
    {
        if (_target == null)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, _target.position+_offset, Time.deltaTime*_smoothness);
    }
}
