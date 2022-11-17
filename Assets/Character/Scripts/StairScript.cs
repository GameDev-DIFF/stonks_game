using UnityEngine;

namespace Character.Scripts
{
    public class StairScript : MonoBehaviour
    {
        [SerializeField] private bool isHigh;
        private PlayerMovement playerMovement;
        [SerializeField] private Transform target;
    
        void Start()
        {
            playerMovement = target.gameObject.GetComponent<PlayerMovement>();
        }

        void Update()
        {
            // if (InputManager.Instance.GetKey("Crouch") && playerMovement.isGrounded())
            // {
            //     transform.parent.GetComponent<Collider2D>().enabled = false;
            // }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log(col.gameObject.tag);
            if (col.gameObject.CompareTag("Player"))
            {
                transform.parent.GetComponent<Collider2D>().enabled = isHigh;
            }
        }
    }
}
