using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField]
    ParticleSystem deathParticles;

    // Start is called before the first frame update
  
    public void ShowDeathParticles()
    {
        GameObject player = UpdateScript.player;
        ParticleSystem.MainModule deathParticlesMain = deathParticles.main;
        deathParticlesMain.startColor = Dimensions.currentColor;

        Instantiate(deathParticles, player.gameObject.transform.position, player.gameObject.transform.rotation, gameObject.transform);
    }

}
