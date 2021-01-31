using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownController : MonoBehaviour
{
    public TimerService timer;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = buildCountDownText();
    }

    string buildCountDownText()
    {
        return string.Format("{0,2:D2}",timer.getMinutes()) + ":" + string.Format("{0,2:D2}", timer.getSeconds());
    }
}
