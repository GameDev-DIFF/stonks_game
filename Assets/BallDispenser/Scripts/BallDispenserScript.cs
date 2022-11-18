using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDispenserScript : MonoBehaviour
{
    private int seconds;
    private BallDispenserScript ballDispencer;
    [SerializeField] private GameObject[] ballInstance;
    private int ballCount;

    private void Start()
    {
        ballDispencer = gameObject.GetComponent<BallDispenserScript>();
    }

    private void LateUpdate()
    {
        foreach (var t in ballInstance)
        {
            var dinges = t.GetComponent<Rigidbody2D>().velocity;
            t.GetComponent<Rigidbody2D>().velocity = 5f * dinges.normalized;
        }
    }

    void Update()
    {
        if (Time.time > seconds && ballCount < 3)
        {
            ballInstance[ballCount].SetActive(true);
            ballInstance[ballCount].transform.position = ballDispencer.transform.position;
            ballInstance[ballCount].GetComponent<Rigidbody2D>().velocity = new Vector2(-10f, 0);

            seconds += 5;
            ballCount++;
        }
    }
}
