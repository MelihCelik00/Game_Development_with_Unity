using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDie
{
    [HideInInspector] public Weapon weapon;
    [HideInInspector] public float Health { get => health; }
    [HideInInspector] public float MoveSpeed { get => moveSpeed; }

    [SerializeField] private float health;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int healthRegenSpeed;
    [SerializeField] private GameObject gunPrefab;

    private bool Armed = false;

    private void Start()
    {
        SpawnGun();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void SpawnGun()
    {
        Transform hand = GameObject.Find("Hand").transform;
        weapon = Instantiate(gunPrefab, hand.position, hand.rotation, hand).GetComponent<Weapon>();
    }

}