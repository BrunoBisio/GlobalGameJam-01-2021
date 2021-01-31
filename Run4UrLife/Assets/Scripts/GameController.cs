using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum states
{
    playing,
    scene1,
    scene2,
    scene3,
    lastChapter,
    menu
}
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
    public states state = states.menu;
    public GameObject Scene1;
    public TimerService timer;
    public bool scene1Viewed = false;
    public List<Scene1> scenes = new List<Scene1>();
    public Menu menu;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Cost cost;
        switch (state)
        {
            case states.playing:
                Time.timeScale = 1;
                //Scene1.SetActive(false);
                break;
            case states.scene1:
                Time.timeScale = 0;
                 cost = scenes[0].playScene1();
                timer.decreaseTimer(cost.timeCost);
                state = cost.state;
                break;
            case states.scene2:
                Time.timeScale = 0;
                 cost = scenes[1].playScene1();
                timer.decreaseTimer(cost.timeCost);
                state = cost.state;
                break;
            case states.scene3:
                Time.timeScale = 0;
                 cost = scenes[2].playScene1();
                timer.decreaseTimer(cost.timeCost);
                state = cost.state;
                break;
            case states.lastChapter:
                Time.timeScale = 0;
                 cost = scenes[3].playScene1();
                timer.decreaseTimer(cost.timeCost);
                state = cost.state;
                break;
            case states.menu:
                Time.timeScale = 0;
                menu.toggleMenu(true);
                break;
        }
        
    }

    private void FixedUpdate()
    {
        foreach(Scene1 scene in scenes)
        {
            if (!scene.Viewed && player.transform.position.x >= scene.xCondition)
            {
                this.state = scene.Enable();
            }
        }
       
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
            //distanceOfWalls = wallController.generateWall(distanceOfWalls) +10;
        }
        if (distanceOfWalls - player.transform.position.x < creationLimit)
        {
            distanceOfWalls = wallController.generateWall(distanceOfWalls) + 10;
        }
    }
}
