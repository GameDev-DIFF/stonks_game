using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpPower;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = new Vector2(jumpPower, rb.velocity.y);
        }
    }
}
