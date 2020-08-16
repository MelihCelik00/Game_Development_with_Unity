using System.Xml.Schema;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Patrol : MonoBehaviour
{
    //public Transform[] patrolMovePoints;
    //public Transform moveSpot;
    //private int randomSpot;

    public NavMeshAgent agent;
    //private float waitTime;
    //public float startWaitTime;

    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;

    private Animator anims;

    [SerializeField] private GameObject newPointObject;
    private GameObject newObject;

    private EnemyController enemyController;

    private void Start()
    {
        
        enemyController = GetComponent<EnemyController>();
        //waitTime = startWaitTime;
        agent = GetComponent<NavMeshAgent>();
        anims = GetComponentInChildren<Animator>();

        //Set New Point
        InstantiateNewPoint();
    }
    
    private void Update()
    {
        //Debug.Log("Enemy is in area?");
        //Debug.Log(enemyController.NotInArea);
        
        if (enemyController.NotInArea)
        {
            PatrolAutomation();
        }
        
    }
    
    public void PatrolAutomation()
    {
        DoPatrol();

        //if (Vector3.Distance(transform.position, patrolMovePoints[randomSpot].position) < 2f)
        if(Vector3.Distance(transform.position, newObject.transform.position) < 4f)
        {
            SetNewRandomPoint();
            /*
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
            */
        }
    }

    private void DoPatrol()
    {
        agent.speed = 3;
        //transform.position = Vector3.MoveTowards(transform.position, patrolMovePoints[randomSpot].position, agent.speed * Time.deltaTime); // For the set of point
        //transform.position = Vector3.MoveTowards(transform.position, newObject.transform.position, agent.speed * Time.deltaTime); // For the random points in the area
        //agent.SetDestination(newObject.transform.position);
        //agent.transform.LookAt(newObject.transform.position);
        agent.destination = newObject.transform.position;
        anims.SetBool("ifAttack",false);
        anims.SetFloat("Movement",1);
    }

    public void SetNewRandomPoint()
    {
        newObject.transform.position = new Vector3(Random.Range(minX,maxX), 0, Random.Range(minZ,maxZ));
    }
    
    private void InstantiateNewPoint()
    {
        Vector3 newPos = new Vector3(Random.Range(minX,maxX), 0, Random.Range(minZ,maxZ));
        newObject = Instantiate(newPointObject, newPos, Quaternion.identity);
        
    }
    
    /*
    private void SetNewPoint() // Goes to all of the given points randomly
    {
        randomSpot = Random.Range(0, patrolMovePoints.Length);
    }
    */
    
    //
    //
    // Surface'da bake edilen yerlere waypoint atamayacak bi method yazılacak!
    //
    //
}