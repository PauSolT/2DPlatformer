using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Dimensions : MonoBehaviour
{
    public static int layer = 8;
    [SerializeField]
    int minimumLayer;
    [SerializeField]
    int maximumLayer;
    int minRgbLayer = 8;
    int maxRgbLayer = 10;
    int minBwLayer = 11;
    int maxBwLayer = 12;

    public TilemapCollider2D[] colliders;
    public Tilemap[] maps;
    public Tilemap[] spikes;

    public GameObject rgb;
    public GameObject bw;

    Color[] playerColors = new Color[] { Color.red, Color.green, Color.blue, Color.black, Color.white };
    public static Color currentColor;

    bool canChange = true;
    bool isRgb = true;
    bool canChangeWorld = true;

    SpriteRenderer currentColorSprite;
    public ParticleSystem ChangeDimensionParticles;

    public ParticleSystem.MainModule ChangeDimensionParticlesMain;

    void Start()
    {
        minimumLayer = minRgbLayer;
        maximumLayer = maxRgbLayer;
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
        ChangeWorld();
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

    void ChangeWorld ()
    {
        if (Input.GetKeyDown(KeyCode.P))
            ChangeWorlds();
    }

    void AssignDimension (int numLayer)
    {
        gameObject.layer = numLayer;
        layer = numLayer;
        Debug.Log("Layer" + layer);
        Debug.Log("Gravity before" + Physics2D.gravity);

        if (layer == minBwLayer)
            Physics2D.gravity = new Vector2(0, 9.8f);
        else
            Physics2D.gravity = new Vector2(0, -9.8f);

        Debug.Log("Gravity after" + Physics2D.gravity);


        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].isTrigger = false;
            maps[i].color = new Color(maps[i].color.r, maps[i].color.g, maps[i].color.b, 1);
            spikes[i].color = new Color(maps[i].color.r, maps[i].color.g, maps[i].color.b, 1);
        }

        colliders[numLayer - minRgbLayer].isTrigger = true;
        AssignColors(numLayer);
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

    void AssignColors(int numLayer)
    {
        Color currentLayerColor = maps[numLayer - minRgbLayer].color;
        maps[numLayer - minRgbLayer].color = new Color(currentLayerColor.r, currentLayerColor.g, currentLayerColor.b, 0.25f);
        spikes[numLayer - minRgbLayer].color = new Color(currentLayerColor.r, currentLayerColor.g, currentLayerColor.b, 0.25f);
        currentColorSprite.color = playerColors[numLayer - minRgbLayer];
        currentColor = playerColors[numLayer - minRgbLayer];
        ChangeDimensionParticlesMain.startColor = playerColors[numLayer - minRgbLayer];
    }

    void ChangeWorlds()
    {
        if (canChangeWorld)
        {
            if (isRgb)
            {
                isRgb = false;
                minimumLayer = minBwLayer;
                maximumLayer = maxBwLayer;
            } else
            {
                isRgb = true;
                minimumLayer = minRgbLayer;
                maximumLayer = maxRgbLayer;
            }
            rgb.SetActive(isRgb);
            bw.SetActive(!isRgb);
            AssignDimension(minimumLayer);
        }
    }

}
