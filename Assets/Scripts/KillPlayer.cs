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
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Instantiate(DeathParticles, player.gameObject.transform.position, player.gameObject.transform.rotation,gameObject.transform );
            //TODO change particles color
            //DeathParticlesMain.startColor = playerColors[layer - minimumLayer];
            PlayerMovement.KillPlayer();
        }
    }
}
