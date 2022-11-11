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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>()?.TakeDamage(damage);

            var force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-force.x, force.y * 2, force.z) * 10, ForceMode2D.Impulse);

            if (!movement.playerCollision)
            {
                movement.playerCollision = true;
            }
        } 
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        movement.playerCollision = false;
    }
}
