using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    int collectiblesObtained = 0;
    public int maxCollectibles = 0;
    //public Collectible[] levelCollectibles;
    public List<Collectible> levelCollectibles;

    public void CheckCollectibles()
    {
        foreach (Collectible collectible in levelCollectibles)
        {
            if (collectible.playerObtainedCollectible && (collectible.obtainedAlready == false))
            {
                collectiblesObtained++;
                collectible.gameObject.SetActive(false);
                collectible.obtainedAlready = true;
                Debug.Log("Collectibles Obtained: " + collectiblesObtained);
            }
        }
    }

    private void Start()
    {
        maxCollectibles = levelCollectibles.Capacity;
    }

    private void Update()
    {
        CheckCollectibles();
    }
}
