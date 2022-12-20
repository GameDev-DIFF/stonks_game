using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealSecretRoom : MonoBehaviour
{
    [SerializeField] private GameObject hiddenRoom;
    [SerializeField] private CameraMovement cameraMovement;
    public bool enteredRoom = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            cameraMovement.revealSecret = true;
            enteredRoom = true;
            hiddenRoom.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerInteraction"))
        {
            cameraMovement.revealSecret = false;
            enteredRoom = false;
            hiddenRoom.SetActive(true);
        }
    }
}
