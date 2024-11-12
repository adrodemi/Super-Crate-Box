using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float runSpeed = 35f;

    public SpriteRenderer sprite;
    public int direction = 1;

    public float jumpForce = 10f;
    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;

    private bool isGrounded;

    private float inputHorizontal;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        Jump();
        rb.velocity = new Vector2(inputHorizontal * runSpeed, rb.velocity.y);
        if (inputHorizontal < 0 && direction > 0)
            Flip();
        else if (inputHorizontal > 0 && direction < 0)
            Flip();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
    private void Jump()
    {
        if (Input.GetButton("Jump"))
        {
            if (isGrounded) jumpControl = true;
        }
        else jumpControl = false;

        if (jumpControl)
        {
            if (jumpIteration++ < jumpValueIteration)
                rb.AddForce(Vector2.up * jumpForce * 10 / jumpIteration);
        }
        else
            jumpIteration = 0;
    }
    private void Flip()
    {
        sprite.flipX = !sprite.flipX;
        direction *= -1;
    }
}