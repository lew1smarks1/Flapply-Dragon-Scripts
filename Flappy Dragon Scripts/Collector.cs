using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    //strange name "Collector" used, this script is attached to the upper and lower bounds of the game
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.isDead = true;
        }
    }
}
