using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float _coeffConst = 0.05f;
    

    private void FixedUpdate()
    {
        transform.position += Vector3.down * (Time.deltaTime * FindObjectOfType<ObjectSpawner>().FallSpeed);
        
        
    }
}