using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform player;

    [Header("Moving Points")]
    [SerializeField] private Transform topEdge;
    [SerializeField] private Transform bottemEdge;
    [SerializeField] private float speed;
    private bool movingUp = true;

    // Update is called once per frame
    void Update()
    {
        if (movingUp)
        {
            if (transform.position.y >= bottemEdge.position.y)
                MoveInDirection(-1);
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y <= topEdge.position.y)
                MoveInDirection(1);
            else
                movingUp = true;
        }
    }

    private void MoveInDirection(int _direction)
    {
        //Move in direction
        transform.position = new Vector3(transform.position.x,
            transform.position.y + Time.deltaTime * _direction * speed, transform.position.z);
    }
}
