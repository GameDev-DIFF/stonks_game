using UnityEngine;

namespace Character.Scripts
{
    public class StairScript : MonoBehaviour
    {
        [SerializeField] private bool isHigh;
        [SerializeField] private Transform target;
 
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
