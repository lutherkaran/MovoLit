using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D colli;
    SpriteRenderer sprite;
    
    public void Awake() {
        colli = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Start() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Torch"))
            {
            sprite.color = Color.red;
            
        }
        colli.isTrigger = false;
    }
    /*private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Torch"))
        {
            sprite.color = Color.green;
            colli.isTrigger = true;
        }
    }*/
}
