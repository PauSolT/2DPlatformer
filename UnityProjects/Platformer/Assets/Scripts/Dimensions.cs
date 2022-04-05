using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dimensions : MonoBehaviour
{
    public static int layer = 8;
    int minimumLayer = 8;
    int maximumLayer = 10;

    public TilemapCollider2D[] rgbColliders;
    public Tilemap[] rgbMaps;

    Color notCurrentLayer = new Color(1, 1, 1, 1);
    Color currentLayer = new Color(1, 1, 1, 0.25f);
    Color[] playerColors = new Color[] { Color.red, Color.green, Color.blue };

    bool canChange = true;

    SpriteRenderer currentColor;
    public ParticleSystem ChangeDimensionParticles;
    public ParticleSystem DeathParticles;

    public ParticleSystem.MainModule ChangeDimensionParticlesMain;
    public ParticleSystem.MainModule DeathParticlesMain;

    void Start()
    {
        currentColor = gameObject.GetComponent<SpriteRenderer>();
        ChangeDimensionParticlesMain = ChangeDimensionParticles.main;
        DeathParticlesMain = DeathParticles.main;
        AssignDimension(layer);
    }

    // Update is called once per frame
    public void Updating()
    {
        ChangeColor();
    }

    void ChangeColor()
    {
        LessDimension(minimumLayer, maximumLayer);
        MoreDimension(minimumLayer, maximumLayer);
    }

    void LessDimension(int minimum, int maximum)
    {
        if (Input.GetKeyDown(KeyCode.Q) && canChange)
        {
            layer--;
            layer = layer < minimum ? maximum : layer;
            AssignDimension(layer);
        }
    }

    void MoreDimension(int minimum, int maximum)
    {

        if (Input.GetKeyDown(KeyCode.E) && canChange)
        {
            layer++;
            layer = layer > maximum ? minimum : layer;
            AssignDimension(layer);
        }
    }

    void AssignDimension (int layer)
    {
        gameObject.layer = layer;
        for (int i = 0; i < rgbColliders.Length; i++)
        {
            rgbColliders[i].isTrigger = false;
            rgbMaps[i].color = notCurrentLayer;
        }

        rgbColliders[layer - minimumLayer].isTrigger = true;
        rgbMaps[layer - minimumLayer].color = currentLayer;
        currentColor.color = playerColors[layer - minimumLayer];
        ChangeDimensionParticlesMain.startColor = playerColors[layer - minimumLayer];
        ChangeDimensionParticles.Play();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            canChange = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            canChange = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layer)
        {
            canChange = true;
        }
    }

    private void OnDestroy()
    {
        
        DeathParticlesMain.startColor = playerColors[layer - minimumLayer];
        Instantiate(DeathParticles, gameObject.transform);
        Debug.Log("DESTROYED");
    }
}
