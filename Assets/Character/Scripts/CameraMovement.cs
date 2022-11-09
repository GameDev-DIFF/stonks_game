using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float SmoothValue = 0.15f;
    private Vector3 velocity = Vector3.zero;
    private bool isHigh;
    private PlayerMovement playerMovement;
    
    [SerializeField] private Transform target;

    private void Awake()
    {
        playerMovement = target.gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float y = 3.25f;
        switch (target.position.y)
        {
            case > 3f:
            {
                if (playerMovement.IsGrounded())
                {
                    isHigh = true;
                }

                if (isHigh)
                {
                    y = target.position.y;
                }

                break;
            }
            case < -0.2f:
                y = target.position.y + 2f;
                isHigh = false;
                break;
            default:
                isHigh = false;
                break;
        }

        Vector3 targetPosition = new Vector3(target.position.x, y, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothValue);
    }
}