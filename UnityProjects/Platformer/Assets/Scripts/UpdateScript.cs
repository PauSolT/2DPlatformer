using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScript : MonoBehaviour
{
    Dimensions dimensions;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        dimensions = GetComponent<Dimensions>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement.Updating();
        dimensions.Updating();
    }

    void FixedUpdate()
    {
        playerMovement.FixedUpdating();
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.55f, Color.black);

    }
}
