using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch :MonoBehaviour
{
    Rigidbody2D rb;
    public float force;

    public void Initialize()
    {
        rb =  GetComponent<Rigidbody2D>();
        
    }

    public void ThrowTorch(Vector2 dir)
    {
        rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
        
    }

  

}
