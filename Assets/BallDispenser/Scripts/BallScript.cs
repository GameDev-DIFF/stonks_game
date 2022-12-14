using UnityEngine;

namespace BallDispenser.Scripts
{
    public class BallScript : MonoBehaviour
    {
        [SerializeField] private GameObject ballDispencer;

        private void Start()
        {
            Physics2D.IgnoreCollision(ballDispencer.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>(), true);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                col.gameObject.GetComponent<Health>()?.TakeDamage(1);
            }
        }
    }
}