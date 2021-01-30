using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1 : MonoBehaviour
{


    public GameObject scene;
    public bool Viewed = false;
    public float xCondition = 10f;
    public Text textBox;
    public List<string> texts = new List<string>();
    public int correctOption = 1;
    public List<float> costs = new List<float>();
    public states state;
    // Start is called before the first frame update
    void Start()
    {
        //texts.Add(string.Format("Texto random de ejemplo, che puto como estas \n a re loco"));
        //texts.Add(string.Format("Segundo texto random de ejemplo, a que esto es genial"));
        //texts.Add(string.Format("Ojala esto termine pronto..."));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public states Enable()
    {
        this.Viewed = true;
        scene.SetActive(true);
        loadText();
        return states.scene1;
    }

    private void loadText()
    {
        textBox.text = texts[0];
        texts.RemoveAt(0);
    }
    public Cost playScene1()
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
                if (Input.GetKeyDown(x.ToString()))
                {
                    if (correctOption == x)
                    {
                        scene.SetActive(false);
                        return new Cost(costs[x], states.playing);
                    }
                    return new Cost(costs[x], state);
                }
            }
        }
        return new Cost(0f, state);
    }
}
