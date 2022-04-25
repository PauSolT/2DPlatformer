using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillColorPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && 
            col.gameObject.layer != gameObject.layer)
        {
            GameObject player = col.gameObject;
            player.GetComponent<PlayerMovement>().KillPlayer();
        }
    }
}
