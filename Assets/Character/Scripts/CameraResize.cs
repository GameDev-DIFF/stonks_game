using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResize : MonoBehaviour
{
    public Camera mainCamera;
    public CameraMovement cameraMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            mainCamera.orthographicSize = 19;
            cameraMovement.changedCamera = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            mainCamera.orthographicSize = 5;
            cameraMovement.changedCamera = false;
        }
    }
}
