using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected float damage;
    private EnemyMovement movement;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Health>()?.TakeDamage(damage);
            if (!movement.playerCollision)
            {
                movement.playerCollision = true;
            }
        } 
    }

    private void OnCollisionExit(Collision collision)
    {
        movement.playerCollision = false;
    }
}
