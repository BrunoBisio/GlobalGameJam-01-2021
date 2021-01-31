using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

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
    public GameObject blackOutSquare;
    public Sprite nextBackground;
    public GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        scene.SetActive(false);
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
        StartCoroutine(FadeSquare());
        loadText();
        return state;
    }

    private void internalEnable()
    {
        scene.SetActive(true);
    }
    public void loadText()
    {
        textBox.text = string.Format(Regex.Unescape(texts[0]));
        texts.RemoveAt(0);
    }
    public virtual Cost playScene1()
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
                        return new Cost(costs[x], states.playing);
                    }
                    return new Cost(costs[x], state);
                }
            }
        }
        return new Cost(0f, state);
    }

    public IEnumerator FadeSquare(bool fadeToBlack = true, float speed = .1f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;
        if(fadeToBlack)
        {
            while(blackOutSquare.GetComponent<Image>().color.a<1)
            {
                fadeAmount = objectColor.a + (speed);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return new WaitForSecondsRealtime(.1f);
            }
            internalEnable();
            StartCoroutine(FadeSquare(false));
        } else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (speed);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return new WaitForSecondsRealtime(.1f);
            }
        }
    }
}
