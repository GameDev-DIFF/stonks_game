using UnityEngine;

namespace Character.Scripts
{
    public class StairScript : MonoBehaviour
    { 
        private void OnTriggerEnter2D(Collider2D col)
        {
            switch (GetComponent<Collider2D>().tag)
            {
                case "UnderneathStair":
                    Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), col, true);
                    break;
                case "AboveStair":
                    Physics2D.IgnoreCollision(transform.parent.GetComponent<Collider2D>(), col, false);
                    break;
            }
        }
    }
}