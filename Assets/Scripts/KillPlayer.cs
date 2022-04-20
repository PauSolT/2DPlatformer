using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public ParticleSystem DeathParticles;
    ParticleSystem.MainModule DeathParticlesMain;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameObject player = col.gameObject;
            player.GetComponent<PlayerMovement>().KillPlayer();
        }
    }
}
