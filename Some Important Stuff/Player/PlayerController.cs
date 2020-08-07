using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Joystick joystick;
    private Player player;
    private Vector3 movement = Vector3.zero;
    private CharacterController characterController;

    public Vector3 Movement { get => movement; }

    private void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        player = GetComponent<Player>();
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        movement.x = joystick.Horizontal;
        movement.z = joystick.Vertical;

        // HAREKET
        characterController.Move(Movement * Time.deltaTime * player.MoveSpeed);
    }

}