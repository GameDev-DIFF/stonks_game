using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSquare : MonoBehaviour
{
    [SerializeField] protected float damage;

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            collision.gameObject.GetComponent<Health>()?.TakeDamage(damage);
=======
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);

            var force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-force.x, -force.y, force.z) * 10, ForceMode2D.Impulse);
>>>>>>> 76839ea75d43dbed2e326689d2b85e49bac04f0d
        }
    }
}