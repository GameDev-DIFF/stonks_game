using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    [SerializeField] private float jumpPower;
    [SerializeField] private BoxCollider2D standingCollider, crouchingCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask whatIsLadder;
    [SerializeField] private Transform playerForm;
    private bool isCrouching = false;
    private bool isClimbing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Moves the player accross the horizontal axis.
        horizontalInput = InputManager.Instance.GetAxis("Horizontal");
        if (horizontalInput != 0)
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Ladder climbing
        climbing();

        // Checks if the player wants to jump
        if (InputManager.Instance.GetKey("Jump"))
        {
            Jump();
        }

        // Checks if the player wants to crouch
        if (InputManager.Instance.GetKey("Crouch"))
        {
            Crouch();
        }
        else
        {
            playerForm.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // Chances direction of player
/*        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }*/
    }

    private void Jump()
    {
        // Gets the velocity from the rigidbody for the x axis and adds an amount to the y axis.
        if (isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    private void Crouch()
    {
        playerForm.transform.localScale = new Vector3(1f, 0.5f, 1f);
    }

    private void climbing()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
            isClimbing = true;
        else
            isClimbing = false;

        if (isClimbing == true)
        {
            verticalInput = InputManager.Instance.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(standingCollider.bounds.center, standingCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
