using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{

    public  GameObject prefab;
    public  GameObject[] platform = null;
    public  float maxDistanceX = 3;
    public float maxDistanceY = 3;
    [Header("Seed")]
    public float seed = 1.25f;
    public bool random = false;
    [Header("PlatformSizes")]
    public float xSize = 1;
    public float ySize = 1;
    [Header("Resize")]
    public float xReSize = 1f;
    public float yReSize = 1f;

    private float lastNoise = 0;
    private float diffBetweenNoises = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(random) {
            generateSeed();
        }
        
        createElements();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void createElements()
    {
        /*if(platform != null)
        {
            for (int x = 0; x < 10; x++)
            {
                if(platform[x]!= null)
                {
                    Destroy(platform[x]);
                }
                
            }
        }*/
        platform = new GameObject[10];
        for (int x = 0; x < 10; x++)
        {
            float yDistance = (float)getPerlinNoise(x, seed, maxDistanceY);
            if(lastNoise != 0)
            {
                diffBetweenNoises += lastNoise - yDistance;
            }
            lastNoise = yDistance;
            float xDistance = (float)getPerlinNoise(x, seed, maxDistanceX);
            platform[x] = Instantiate(prefab, new Vector2((x * xSize) + xDistance, yDistance), Quaternion.identity);
            platform[x].transform.localScale = new Vector2(xReSize, yReSize);
        }
    }

    public void generateSeed()
    {
        seed = Random.Range(0f, 1000f);
    }

    public void changeNoise()
    {
        if(true)
        {
            generateSeed();
        }
    }

    public static double getPerlinNoise(float x, float seed, float maxSize)
    {
        return (Mathf.PerlinNoise(x, seed) -0.5) * maxSize + (maxSize/2);
    }
}
