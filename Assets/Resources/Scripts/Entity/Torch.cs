using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Torch :MonoBehaviour
{
    public Rigidbody2D rb;
    public float force;

    TextMeshProUGUI torchPickText;
    RectTransform torchTextTransform;
    Vector3 textOffset = new Vector3(0, 1, 0);

    private Camera cam;

    bool isPickedUp = false;

    public void Initialize()
    {
        rb =  GetComponent<Rigidbody2D>();
        cam = Camera.main;

        try
        {
            torchPickText = GameObject.FindGameObjectWithTag("TorchText").GetComponent<TextMeshProUGUI>();
            torchTextTransform = torchPickText.GetComponent<RectTransform>();
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }
    }

    public void Refresh()
    {
        isPickedUp = transform.parent ? true : false;

        try
        {
            if (torchPickText.gameObject != null)
            {
                if (!isPickedUp && Mathf.Abs(rb.velocity.x) < 2f && Mathf.Abs(rb.velocity.y) < 2f)
                {
                    Collider2D col = Physics2D.OverlapCircle(transform.position, .5f, LayerMask.GetMask("Player"));
                    if (col)
                    {
                        torchPickText.gameObject.SetActive(true);
                        torchTextTransform.position = cam.WorldToScreenPoint(transform.position + textOffset);
                    }
                    else
                    {
                        torchPickText.gameObject.SetActive(false);
                    }
                }
                else
                {
                    torchPickText.gameObject.SetActive(false);
                }

            }
        }
        catch (System.Exception e)
        {
            Debug.LogException(e, this);
        }
    }




}
