using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch :MonoBehaviour
{
   public Rigidbody2D rb;
    public float force;

    public void Initialize()
    {
        rb =  GetComponent<Rigidbody2D>(); 
    }

   

  

}
