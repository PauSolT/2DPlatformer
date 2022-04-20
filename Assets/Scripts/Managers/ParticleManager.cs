using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    ParticleSystem deathParticles;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void ShowDeathParticles()
    {
        ParticleSystem.MainModule deathParticlesMain = deathParticles.main;
        deathParticlesMain.startColor = Dimensions.currentColor;

        Instantiate(deathParticles, player.gameObject.transform.position, player.gameObject.transform.rotation, gameObject.transform);
    }

}
