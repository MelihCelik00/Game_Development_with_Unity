using UnityEngine;

public class BallController : MonoBehaviour
{
   [SerializeField]
   private float _moveSpeed = 1f;
   private float _jumpSpeed = 8f;

   private bool isGrounded;
   private Rigidbody _rigidbody;

   private Vector3 _pos;
   private void Start()
   {
      _rigidbody = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      CheckInput();
      
   }

   private void CheckInput()
   {
      if (Input.GetKey(KeyCode.D))
      {
         Move(Vector3.right);
      }
      else if (Input.GetKey(KeyCode.A))
      {
         Move(Vector3.left);
      }

      if (Input.GetKeyDown(KeyCode.Space))
      {
         Jump();
      }
   }

   private void Jump()
   {
      if (!isGrounded)
         return;
      _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
   }

   private void Move(Vector3 direction)
   {
      _rigidbody.AddForce(direction*_moveSpeed, ForceMode.Acceleration);
   }

   private void OnCollisionEnter(Collision other)
   {
      isGrounded = true;
      
      CheckEnemyCollision(other);
      //hit.collider.GetComponent<Enemy>()?.EnemyDie();
      //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.blue, 3f);
      //bool killEnemy = isTopOfEnemy && hasCollidedWithEnemy;
   }

   private void OnCollisionExit(Collision other)
   {
      isGrounded = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      Collectable collectable = other.GetComponent<Collectable>();   
      bool isCollectable = collectable != null;

      if (isCollectable)
      {
         collectable.Collect();   
      }
   }
   
   private void CheckEnemyCollision(Collision collision)
   {
      bool hasCollidedWithEnemy = collision.collider.GetComponent<Enemy>();
      //bool isTopOfEnemy = false;

      if (!hasCollidedWithEnemy)
      {
         //Debug.Log("!HAS_COLLIDED_WITH_ENEMY");
         return;
      }

      if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
      {
         Enemy enemy = hit.collider.GetComponent<Enemy>();
         bool isOnTopOfEnemy = enemy != null;
         //Debug.Log("IS ON TOP OF ENEMY???: "+isOnTopOfEnemy);
         if (isOnTopOfEnemy)
         {
            //Debug.Log("Enemy DIEEEE"); IT WORKS
            enemy.Die();
            return;
         }
         //Debug.Log("SELF DIEEEEEEEEEE");
         Die();
      }
   }
   
   private void Die()
   {
      Destroy(gameObject);

      LevelManager lm = gameObject.AddComponent<LevelManager>();
      lm.RestartScene();
      GetComponent<MeshRenderer>().enabled=false;
      //Invoke(nameof(ChangeScene),1f);
   }

   
   
}
