using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool playerObtainedCollectible = false;
    public bool obtainedAlready = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerObtainedCollectible = true;
        }
    }
}
