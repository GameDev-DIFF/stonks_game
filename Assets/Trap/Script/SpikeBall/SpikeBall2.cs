using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall2 : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] float movementSpeed;
    [SerializeField] float leftAngle;
    [SerializeField] float rightAngle;

    bool movingClockwise;
    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movingClockwise = true;
        
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void ChangeMovingDirection()
    {
        if(transform.rotation.z > rightAngle)
        {
            movingClockwise = false;
        }
        if (transform.rotation.z < leftAngle)
        {
            movingClockwise = true;
        }
    }

    public void Movement()
    {
        ChangeMovingDirection();

        if(movingClockwise)
        {
            rb2d.angularVelocity = movementSpeed;
        }
        if (!movingClockwise)
        {
            rb2d.angularVelocity = -1 * movementSpeed;
        }
    }
}
