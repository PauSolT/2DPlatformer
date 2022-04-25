using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] levelCheckpoints;
    public static Vector3 respawnPosition;

    float secondsToRespawn = 1.5f;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void CheckLastCheckpoint()
    {
        foreach (Checkpoint checkpoint in levelCheckpoints)
        {
            if (checkpoint.playerHasReached)
                respawnPosition = checkpoint.checkpointPosition;
        }
    }

    public void RespawnPlayer()
    {
        StartCoroutine(WaitToRespawnCoroutine());
    }


    IEnumerator WaitToRespawnCoroutine()
    {
        yield return new WaitForSeconds(secondsToRespawn);
        player.transform.position = respawnPosition;
        player.SetActive(true);
    }


    private void Update()
    {
        CheckLastCheckpoint();
    }
}
