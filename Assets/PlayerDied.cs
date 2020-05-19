using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    PlayerController player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       player =  FindObjectOfType<PlayerController>();
        if (collision.CompareTag("Player")) {
            PlayerManager.instance.PlayerDied(player);
        }
    }
}
