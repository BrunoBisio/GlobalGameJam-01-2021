using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlatformController platformController;
    public WallGenerator wallController;
    public GameObject player;
    public GameObject verticalBarrier;
    private float nextMileStone = 0f;
    private float distanceOfWalls = 0f;
    private float oldMileStone = -1000f;
    public int elementsToCreate = 10;
    public int creationLimit = 10;
    public int deletionLimit = -20;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        wallController.deleteLast(verticalBarrier.transform.position.x);
        if (platformController.lastPlatform != null && platformController.lastPlatform.transform.position.x - verticalBarrier.transform.position.x < deletionLimit)
        {
            platformController.DestroyPlatforms();
            //platformController.baseHeight += 0.1f;
        }
        if (nextMileStone - player.transform.position.x < creationLimit)
        {
            oldMileStone = nextMileStone;
            nextMileStone = platformController.createElements(nextMileStone, elementsToCreate);
            distanceOfWalls = wallController.generateWall(distanceOfWalls) +10;
        }
    }
}
