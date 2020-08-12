using UnityEngine;

public class EnemyAnim : MonoBehaviour
{

    private Animator anims;
    private GameObject player;
    //[SerializeField]
    //private float moveSpeedRun, moveSpeedPatrol;


    // Start is called before the first frame update
    void Start()
    {
        anims = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PatrolAnims()
    {
        //patrol
        anims.SetBool("ifAttack",false);
        anims.SetFloat("Movement",1);
    }

    public void RunToPlayer()
    {

        anims.SetBool("ifAttack",false);
        //transform.LookAt(player.transform.position);
        //transform.position += transform.forward * moveSpeedRun * Time.deltaTime;
        anims.SetFloat("Movement", 2);
    }
    public void Attack()
    {
        anims.SetBool("ifAttack", true);
        //waitforsecond
        //alanın içinde mi ?
        //içindeyse oyuncu canını eksilt
    }
}
