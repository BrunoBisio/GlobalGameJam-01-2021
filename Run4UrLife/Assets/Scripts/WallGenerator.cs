using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public GameObject obstaclesList;
    List<GameObject> obstacles = new List<GameObject>();
    List<GameObject> list =  new List<GameObject>();
    public float seed = 0f;
    private float step = 0f;
    public float distanceBetweenObstacles = 32f;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform obstacle in obstaclesList.transform)
        {
            obstacles.Add(obstacle.gameObject);
        }

        seed = Random.Range(0f, 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void deleteAll()
    {
        while(list.Count > 0)
        {
            Destroy(list[0], 0.5f);
            list.RemoveAt(0);
        }
    }
    public void deleteLast(float x)
    {
        if(list.Count > 0)
        {
            if (list[0].transform.position.x - x < -10)
            {
                Destroy(list[0], 0.5f);
                list.RemoveAt(0);
            }
        }
     
    }

    public float generateWall(float baseX)
    {
        float noise = Mathf.PerlinNoise(step, seed);
        int choice = Mathf.RoundToInt(scale(0, 1, 0, obstacles.Count - 1, noise));
        GameObject platform = Instantiate(obstacles[choice], new Vector2(baseX, -9.3f), Quaternion.identity);
        step += Random.Range(0f, 2f);
        list.Add(platform);
        return baseX+ distanceBetweenObstacles;
    }


    public float scale(float OldMin, float OldMax, float NewMin, float NewMax, float OldValue)
    {

        float OldRange = (OldMax - OldMin);
        float NewRange = (NewMax - NewMin);
        float NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;

        return (NewValue);
    }

}
