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
            collision.gameObject.GetComponent<Health>()?.TakeDamage(damage);

            var force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-force.x, force.y * 2, force.z) * 500);

            if (!movement.playerCollision)
            {
                movement.playerCollision = true;
            }
        } 
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        movement.playerCollision = false;
    }
}
