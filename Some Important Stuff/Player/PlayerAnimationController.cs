using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private bool FollowEnemy = false;

    private Animator animator;
    private PlayerController playerController;
    private Joystick joystick;
    private Enemy enemy;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        joystick = FindObjectOfType<Joystick>();
        // TEMP
        enemy = FindObjectOfType<Enemy>();
    }

    void FixedUpdate()
    {
        // ENEMY TESPIT ETMEK
        // ALAN ICINDE ISE DUSMANA BAKSIN
        // YOKSA NORMAL OYUNCU KONTROLUNDE ACISINI DEVAM ETTIRSIN
        float verticalPos, horizontalPos;

        if (FollowEnemy)
        {
            verticalPos = joystick.Vertical;
            horizontalPos = joystick.Horizontal;
        }
        else
        {
            verticalPos = Mathf.Abs(joystick.Vertical);
            horizontalPos = -joystick.Horizontal;
        }

        // BAKIS ACISI 
        if (playerController.Movement != Vector3.zero)
        {
            if (FollowEnemy)
            {
                Quaternion rotation = Quaternion.LookRotation(enemy.transform.position - this.transform.position);
                transform.rotation = rotation;
            }
            // DUSMAN VARSA DUSMANA DOGRU BAKSIN
            else transform.rotation = Quaternion.LookRotation(playerController.Movement);

        }
        Debug.DrawLine(transform.position, enemy.transform.position);
        // ANIMASYON 
        animator.SetFloat("posX", horizontalPos);
        animator.SetFloat("posY", verticalPos);
    }

}
