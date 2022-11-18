using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisposeBallScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            col.gameObject.SetActive(false);
        }
    }
}
