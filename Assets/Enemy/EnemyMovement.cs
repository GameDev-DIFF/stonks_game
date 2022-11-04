using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private Rigidbody2D body;
    private Vector3 initScale;
    private bool movingLeft = true;

    private void Awake()
    {
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
        {
            if (transform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                movingLeft = false;
        } else
        {
            if (transform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                movingLeft = true;
        }
    }

    private void MoveInDirection(int _direction)
    {
        //Make enemy face direction
        transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        //Move in that direction
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed,
            transform.position.y, transform.position.z);
    }
}
