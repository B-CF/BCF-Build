using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //needed variables to edit in unity
    public float playerSpeed;
    public Vector2 jumpForce;
    public Vector2 runForce;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(-runForce, ForceMode2D.Impulse);
        }

        

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(runForce, ForceMode2D.Impulse);
        }

        //jump/move in y direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
    //Update is called multiple times a frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3 (x * playerSpeed, rb.velocity.y, 0f);
        rb.velocity = move;
    }
}
