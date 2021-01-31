using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public float timeLeft = 10f;
    public Scene1 lastScene;
    public bool internalEnabled = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (internalEnabled)
        {
            decreaseTimer(Time.deltaTime);
            if (timeLeft <= 0)
            {
                internalEnabled = false;
                lastScene.Enable();
            }
        }
        
    }

    public int getSeconds()
    {
        int res = Mathf.FloorToInt(timeLeft % 60);
        return res < 0 ? 0 : res;
    }

    public int getMinutes()
    {
        int res = Mathf.FloorToInt(timeLeft / 60);
        return res < 0 ? 0 : res;
    }

    public void decreaseTimer(float time)
    {
        timeLeft -= time;
    }
}
