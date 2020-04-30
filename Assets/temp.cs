using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 inputDir;
    float velocity = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        

    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputDir.x = -1;
            rb.velocity = inputDir.normalized * velocity;

        }if (Input.GetKey(KeyCode.D))
        {
            inputDir.x = 1;
            rb.velocity = inputDir.normalized * velocity;
        }


    }
   
}
