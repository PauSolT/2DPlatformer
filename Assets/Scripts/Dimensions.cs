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
    public Tilemap[] rgbSpikes;

    Color[] playerColors = new Color[] { Color.red, Color.green, Color.blue };
    public static Color currentColor;

    bool canChange = true;

    SpriteRenderer currentColorSprite;
    public ParticleSystem ChangeDimensionParticles;

    public ParticleSystem.MainModule ChangeDimensionParticlesMain;

    void Start()
    {
        currentColorSprite = gameObject.GetComponent<SpriteRenderer>();
        ChangeDimensionParticlesMain = ChangeDimensionParticles.main;
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
            rgbMaps[i].color = new Color(rgbMaps[i].color.r, rgbMaps[i].color.g, rgbMaps[i].color.b, 1);
            rgbSpikes[i].color = new Color(rgbMaps[i].color.r, rgbMaps[i].color.g, rgbMaps[i].color.b, 1);
        }

        rgbColliders[layer - minimumLayer].isTrigger = true;
        Color currentLayerColor = rgbMaps[layer - minimumLayer].color;
        rgbMaps[layer - minimumLayer].color = new Color(currentLayerColor.r, currentLayerColor.g, currentLayerColor.b, 0.25f);
        rgbSpikes[layer - minimumLayer].color = new Color(currentLayerColor.r, currentLayerColor.g, currentLayerColor.b, 0.25f);
        currentColorSprite.color = playerColors[layer - minimumLayer];
        currentColor = playerColors[layer - minimumLayer];
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
}
