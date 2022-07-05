using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 15f;
    public int numberJumps = 2;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform target;
    [SerializeField] SpriteRenderer renderer;

    bool canJump = true;
    float mx;

    public float dashDistance = 15f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;

    private void Update()
    {
        mx = Input.GetAxis("Horizontal");
        Flip();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A))
        { 
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
            }
            else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.D;
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = new Vector2(mx * speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (canJump && numberJumps != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            numberJumps--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
        numberJumps = 2;
    }


    IEnumerator Dash (float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = rb.gravityScale;
        gravity = SetGravity(gravity);
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        rb.gravityScale = gravity;
    }
    private float SetGravity(float gravity)
    {
        if (gravity != 5)
        {
            gravity = 5;
        }
        else
        {
            gravity = rb.gravityScale;
        }
        return gravity;
    }

    private void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            renderer.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            renderer.flipX = true;
        }
    }

}
