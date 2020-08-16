using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceDebugger : MonoBehaviour
{ 
    public Transform target;
    public NavMeshAgent agent;

    private EnemyController controller;
    private bool checker;
    void Start()
    {
        target = PlayerManager.instance.player.transform; // Initialization
        //agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        checker = controller.MenzilCheck;
        float distance = Vector3.Distance(target.position, transform.position);

        if (checker)
        {
            Debug.Log(distance);
        }
        
    }
}
