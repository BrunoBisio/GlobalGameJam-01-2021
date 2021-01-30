using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlatformController platformController;
    public GameObject player;
    private float nextMileStone = 0f;
    private float oldMileStone = 0f;
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
        if(nextMileStone - player.transform.position.x < 10)
        {
            oldMileStone = nextMileStone;
            nextMileStone = platformController.createElements(nextMileStone);
        }
        if (oldMileStone - player.transform.position.x < -20)
        {
            platformController.DestroyPlatforms(10);
        }
    }
}
