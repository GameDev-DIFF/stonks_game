using System;
using UnityEngine;

namespace Character.Scripts
{
    public class StairScript : MonoBehaviour
    {
        [SerializeField] private bool isHigh;
        [SerializeField] private Transform target;

        private void Update()
        {
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (GetComponent<Collider2D>().CompareTag("UnderneathStair"))
            {
                Debug.Log("ondor");
                Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), col, true);
            }
            else if (GetComponent<Collider2D>().CompareTag("AboveStair"))
            {
                Debug.Log("bovon");
                Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), col, false);
            }

            // if (col.gameObject.CompareTag("Player"))
            // {
                // Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), col);
            // }
        }
    }
}