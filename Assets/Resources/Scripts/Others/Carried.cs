using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carried : MonoBehaviour
{
    Collider2D collision;
    Rigidbody2D rb;
    Transform originalParent;
    bool initialColiState;
    RigidbodyType2D initailBodyType;
   

    void PickedUp()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();
        if (collision)
        {
            initialColiState = collision.enabled;
            collision.enabled = false;
        }
        if (rb)
        {
            initailBodyType = rb.bodyType;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            rb.freezeRotation = true;
        }

    }
    public void Dropped()
    {
        //originalParent = transform.parent;
        transform.SetParent(null);
        if (collision)
            collision.enabled = initialColiState;
        if (rb)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 1;
            rb.freezeRotation = true;
        }
        Destroy(this);
    }
    public static Carried PickUpObject(GameObject toCarry, Transform toFollow, Vector2 offset)
    {
        Carried carried = toCarry.AddComponent<Carried>();
        carried.PickedUp();
        carried.transform.SetParent(toFollow);
        carried.transform.localPosition = offset;
        return carried;
    }
}
