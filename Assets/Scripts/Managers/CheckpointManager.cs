using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public Checkpoint[] levelCheckpoints;
    public static Vector3 respawnPosition;

    public void CheckLastCheckpoint()
    {
        foreach (Checkpoint checkpoint in levelCheckpoints)
        {
            if (checkpoint.playerHasReached)
                respawnPosition = checkpoint.checkpointPosition;
        }
    }

    private void Update()
    {
        CheckLastCheckpoint();
    }
}
