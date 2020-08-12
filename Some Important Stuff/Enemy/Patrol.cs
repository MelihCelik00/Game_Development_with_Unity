using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    //public Transform[] patrolMovePoints;
    public Transform moveSpot;
    private int randomSpot;

    private NavMeshAgent agent;
    private float waitTime;
    public float startWaitTime;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private Animator anims;

    
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
        waitTime = startWaitTime;
        agent = GetComponent<NavMeshAgent>();
        anims = GetComponentInChildren<Animator>();

        //SetNewPoint();
        SetNewRandomPoint();
        
    }
    
    private void Update()
    {
        if (enemyController.NotInArea)
        {
            PatrolAutomation();

            if (enemyController.isActive = true)
            {
                agent.Stop();
                
            }
        }
    }

    public void PatrolAutomation()
    {
        DoPatrol();

        //if (Vector3.Distance(transform.position, patrolMovePoints[randomSpot].position) < 2f)
        if(Vector3.Distance(transform.position, moveSpot.position) < 2f)
        {
            if (waitTime<= 0)
            {
                //SetNewPoint();
                SetNewRandomPoint();
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void DoPatrol()
    {
        agent.speed = 1;
        //transform.position = Vector3.MoveTowards(transform.position, patrolMovePoints[randomSpot].position, agent.speed * Time.deltaTime); // For the set of point
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, agent.speed * Time.deltaTime); // For the random points in the area
        agent.transform.LookAt(moveSpot.transform.position);
        anims.SetBool("ifAttack",false);
        anims.SetFloat("Movement",1);
    }
    
    /*
    private void SetNewPoint() // Goes to all of the given points randomly
    {
        randomSpot = Random.Range(0, patrolMovePoints.Length);
    }
    */
    
    public void SetNewRandomPoint()
    {
        moveSpot.position = new Vector3(Random.Range(minX,maxX), 0, Random.Range(minZ,maxZ));
    }
}
