using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private Joystick joystick;
    // PLAYERDAN CEKILECEK
    private Enemy enemy;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        joystick = FindObjectOfType<Joystick>();
    }

    void FixedUpdate()
    {
        float verticalPos = 0, horizontalPos = 0;
        Quaternion lookRotation;
        // BAKIS ACISI 
        if (playerController.Movement != Vector3.zero)
        {
            if (enemy != null)
            {
                lookRotation = Quaternion.LookRotation(enemy.transform.position - this.transform.position);
            }
            else
            {
                lookRotation = Quaternion.LookRotation(playerController.Movement);
            }
            transform.rotation = lookRotation;
        }
        // ANIMASYON
        if (enemy != null)
        {
            Vector3 inputVector = (Vector3.forward * joystick.Vertical + (Vector3.right * joystick.Horizontal));

            Vector3 animationVector = animator.transform.InverseTransformDirection(inputVector);

            verticalPos = animationVector.z;
            horizontalPos = animationVector.x;
        }
        else
        {
            verticalPos = Mathf.Abs(joystick.Vertical);
            horizontalPos = Mathf.Clamp(joystick.Horizontal, -0.75f, 0.75f);
            if (verticalPos < 0.3f)
            {
                verticalPos = Mathf.Abs(horizontalPos);
                horizontalPos = 0;
            }
        }

        // ANIMASYON 
        animator.SetFloat("posX", horizontalPos);
        animator.SetFloat("posY", verticalPos);
    }

}
