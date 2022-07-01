using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //needed variables to edit in unity
    public float speed;
    public Vector2 jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //run in x direction
        transform.Translate(speed * Time.deltaTime, 0f, 0f);

        //jump/move in y direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }
    //Update is called multiple times a frame
    void FixedUpdate()
    {
        
    }
}
