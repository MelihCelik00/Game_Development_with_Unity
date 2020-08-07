using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float attackDistance;
    public float Health { get => health; }

    public Transform target;
    public NavMeshAgent agent;
    private Patrol patrolEnemy;

    public bool NotInArea = false;

    public bool isActive = false;
    private void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() // bool döndür patrol scriptine yolla
    {
        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= attackDistance)
        {
            isActive = true;
            FollowPlayer();
            NotInArea = false;
            if (distance <= agent.stoppingDistance) 
            {
                // Attack the target
                // Face the target
                FaceTarget();  // IT WORKS!
            }
        }
        if (distance > attackDistance)
        {
            NotInArea = true;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void FollowPlayer() // Enemy does not follow Player. Fix it!
    {
        //agent.SetDestination(target.position);
        //agent.destination = target.position;
        agent.transform.position = Vector3.MoveTowards(agent.transform.position, target.position, agent.speed * Time.deltaTime);
    }
    
    public void Attack(){}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
    
}