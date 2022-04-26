using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    int collectiblesObtained = 0;
    public int maxCollectibles = 0;
    public List<Collectible> levelCollectibles;

    private void Start()
    {
        levelCollectibles.AddRange(GetComponentsInChildren<Collectible>());
        maxCollectibles = levelCollectibles.Capacity;
    }

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

   

    private void Update()
    {
        CheckCollectibles();
    }
}
