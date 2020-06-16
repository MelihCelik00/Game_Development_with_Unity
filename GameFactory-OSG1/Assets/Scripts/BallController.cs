using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   public void Die()
   {
      Destroy(gameObject);
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
