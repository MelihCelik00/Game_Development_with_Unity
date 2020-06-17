using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
   [SerializeField]
   private float _moveSpeed = 1f;
   private float _jumpSpeed = 10f;

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
      bool hasCollidedWithEnemy = other.collider.GetComponent<Enemy>();
      //bool isTopOfEnemy = false;
      
      if (hasCollidedWithEnemy)
      {
         if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, Mathf.Infinity))
         {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            bool isOnTopOfEnemy = enemy != null;
            if (isOnTopOfEnemy)
            {
               enemy.Die();
            }
            else
            {
               Die();
            }
            //hit.collider.GetComponent<Enemy>()?.EnemyDie();
         }
         Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.blue, 3f);
      }

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

   private void Die()
   {
      //Destroy(gameObject);

      StartCoroutine(ChangeScene());

      GetComponent<MeshRenderer>().enabled=false;
      //Invoke(nameof(ChangeScene),1f);
   }
   
   private IEnumerator ChangeScene()
   {
      yield return new WaitForSeconds(1f);
        
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
   }
   
   
   /*
   private void SpawnAgain(Vector3 x, Vector3 y)
   {
      if (_rigidbody.transform.position.y > -10)
      {
         return;
      }
      else
      {
         _rigidbody
      }
   }
   */
   
}
