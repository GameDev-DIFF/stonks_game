using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float leftPoint;
    [SerializeField] float rightPoint;
    [SerializeField] float velocityThreshold;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }

    private void Push()
    {
        if(transform.rotation.z > 0)
        {

        }
    }
}
