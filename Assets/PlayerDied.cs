using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDied : MonoBehaviour
{
    PlayerController[] players;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       players =  FindObjectsOfType<PlayerController>();
        if (collision.CompareTag("Player")) {
            PlayerManager.instance.PlayerDied(players);
        }
    }
}
