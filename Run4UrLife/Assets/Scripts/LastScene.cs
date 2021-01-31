using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class LastScene : Scene1
{
    

    public override Cost playScene1()
    {
        if (texts.Count > 0)
        {
            if (Input.anyKeyDown)
            {
                loadText();
            }
        }
        else
        {
            for (int x = 0; x < costs.Count; x++)
            {
                if (Input.GetKeyDown((x+1).ToString()))
                {
                    if (correctOption == (x + 1))
                    {
                        scene.SetActive(false);
                        background.GetComponent<SpriteRenderer>().sprite = nextBackground;
                        return new Cost(costs[x], states.lastCredits);
                    }
                    return new Cost(costs[x], state);
                }
            }
        }
        return new Cost(0f, state);
    }
    
}
