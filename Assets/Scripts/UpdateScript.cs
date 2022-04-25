using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{
    Dimensions dimensions;
    PlayerMovement playerMovement;
    TimeManager timeManager;

    public static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        dimensions = FindObjectOfType<Dimensions>();
        timeManager = FindObjectOfType<TimeManager>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.Updating();
        dimensions.Updating();
        timeManager.UpdateTimer();
    }

    void FixedUpdate()
    {
        playerMovement.FixedUpdating();
    }

}
