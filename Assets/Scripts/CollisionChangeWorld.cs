using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChangeWorld : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Dimensions.canChangeWorld = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dimensions.canChangeWorld = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Dimensions.canChangeWorld = false;
        }
    }
}
