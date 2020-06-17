using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    

    public void Collect()
    {
        FindObjectOfType<ScoreManager>().AddScore(1);
        Destroy(gameObject);
    }
    
}
