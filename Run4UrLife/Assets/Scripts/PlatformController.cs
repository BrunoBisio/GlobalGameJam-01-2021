using UnityEngine;
using System.Collections.Generic;

public enum Seed
{
    X,
    Y
}

public class PlatformController : MonoBehaviour
{

    public  GameObject prefab;
    private Queue<GameObject> queue = new Queue<GameObject>();
    public  float maxDistanceX = 3;
    public float maxDistanceY = 3;
    [Header("Seed")]
    public float seedX = 1.25f;
    public float seedY = 1.25f;
    public bool random = false;
    [Header("PlatformSizes")]
    public float xSize = 1;
    public float ySize = 1;
    [Header("Resize")]
    public float xReSize = 1f;
    public float yReSize = 1f;
    [Header("BaseY")]
    public float baseHeight = 0;

    public int minNumberPlatform = 15;

    private float lastNoise = 0;
    private float diffBetweenNoises = 0;

    public GameObject lastPlatform = null;
    // Start is called before the first frame update
    void Start()
    {
        if(random) {
            generateSeed(Seed.X);
            generateSeed(Seed.Y);
        }
        
        //createElements(0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void destroyAll() {
        while(lastPlatform != null)
        {
            DestroyPlatforms();
        }

    }


    public void DestroyPlatforms()
    {
        if(lastPlatform != null)
        {
            Destroy(lastPlatform, 0.5f);
        }
        if(queue.Count > 0)
        {
            lastPlatform = queue.Dequeue();
        } else
        {
            lastPlatform = null;
        }
        
       
        
    }
    public float createElements(float baseX,  int elemToCreate)
    {
        float xD = baseX;
        for (int x = 0; x < elemToCreate; x++)
        {
            changeNoise(Seed.Y);
            float yDistance = (float)getPerlinNoise(xD, seedY, maxDistanceY);
            if (lastNoise != 0)
            {
                diffBetweenNoises += lastNoise - yDistance;
            }
            lastNoise = yDistance;
            float xDistance = (float)getPerlinNoise(xD, seedX, maxDistanceX);
            xD = createPlatformm(xD, yDistance, xDistance);
        }
        if(lastPlatform == null)
        {
            lastPlatform = queue.Dequeue();
        }
        return xD;
    }

    private float createPlatformm(float xD, float yDistance, float xDistance)
    {
        GameObject platform = Instantiate(prefab, new Vector2((xD) + xDistance, baseHeight + yDistance), Quaternion.identity);
        Renderer re = platform.GetComponent<SpriteRenderer>();

        platform.transform.localScale = new Vector2(xReSize, yReSize);
        //platform.transform.rotation =  
        xD += re.bounds.size.x + xDistance;
        queue.Enqueue(platform);
        return xD;
    }

    public void generateSeed(Seed seed)
    {
        switch(seed)
        {
            case Seed.X:
                seedX = Random.Range(0f, 1000f);
                break;
            case Seed.Y:
                seedY = Random.Range(0f, 1000f);
                break;
        }
        
    }

    public void changeNoise(Seed seed)
    {
        if(Mathf.Abs(diffBetweenNoises) < 2)
        {
            generateSeed(seed);
        }
    }

    public static double getPerlinNoise(float x, float seed, float maxSize)
    {
        return (Mathf.PerlinNoise(x, seed) -0.5) * maxSize + (maxSize/2);
    }
}
