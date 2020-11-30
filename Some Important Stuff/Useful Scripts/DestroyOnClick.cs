using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
