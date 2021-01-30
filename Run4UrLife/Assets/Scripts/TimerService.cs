using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public float timeLeft = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        decreaseTimer(Time.deltaTime);
        if(timeLeft<= 0)
        {
            Time.timeScale = 0;
        }
    }

    public int getSeconds()
    {
        return Mathf.FloorToInt(timeLeft % 60);
    }

    public int getMinutes()
    {
        return Mathf.FloorToInt(timeLeft / 60);
    }

    public void decreaseTimer(float time)
    {
        timeLeft -= time;
    }
}
