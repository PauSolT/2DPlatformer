using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool playerHasReached = false;
    public Vector3 checkpointPosition;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerHasReached = true;
            checkpointPosition = col.gameObject.transform.position;
        }
    }
}
