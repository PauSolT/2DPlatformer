using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] levelCheckpoints;
    public static Vector3 respawnPosition;

    float secondsToRespawn = 1.5f;

    private void Start()
    {
        levelCheckpoints = GetComponentsInChildren<Checkpoint>();
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
        GameObject player = UpdateScript.player;
        CheckLastCheckpoint();

        yield return new WaitForSeconds(secondsToRespawn);
        player.transform.position = respawnPosition;
        player.SetActive(true);
    }

}
