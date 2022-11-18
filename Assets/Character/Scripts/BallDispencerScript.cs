using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDispencerScript : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    private BallDispencerScript ballDispencer;
    private int seconds;
    private GameObject ballInstance;

    void Start()
    {
        ballDispencer = gameObject.GetComponent<BallDispencerScript>();

        ballInstance = Instantiate(ball, ballDispencer.transform.position, Quaternion.identity);
        ballInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f,0);
    }

    private void LateUpdate()
    {
        var dinges = ballInstance.GetComponent<Rigidbody2D>().velocity;
        ballInstance.GetComponent<Rigidbody2D>().velocity = 5f * dinges.normalized;
    }

    void Update()
    {
        // if (Time.time > seconds)
        // {
        //     seconds += 2;
        //     GameObject ballInstance = Instantiate(ball, ballDispencer.transform.position, Quaternion.identity);
        //     ballInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-10f,0);
        // }
    }
}
