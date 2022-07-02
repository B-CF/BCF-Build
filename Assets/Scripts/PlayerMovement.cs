using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //needed variables to edit in unity
    private float realSpeed;
    public float playerSpeed;
    public float dashSpeed;
    public Vector2 jumpForce;
    private bool canJump = true;
    private int numberJumps = 2;

    //get player
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump/move in y direction
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            if (numberJumps != 0)
            {
                rb.AddForce(jumpForce, ForceMode2D.Impulse);
                numberJumps--;
            }
            else
            {
                canJump = false;
            }
        }
    }
    //Update is called multiple times a frame
    void FixedUpdate()
    {
        //sprint 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realSpeed = playerSpeed + dashSpeed;
        }
        else
        {
            realSpeed = playerSpeed;
        }

        //move in x direction -/+
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3 (x * realSpeed, rb.velocity.y, 0f);
        rb.velocity = move;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {    
        canJump = true;
        numberJumps = 2;  
    }
}
