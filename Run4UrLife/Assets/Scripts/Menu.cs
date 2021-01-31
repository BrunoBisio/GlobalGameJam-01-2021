using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum menuState
{
    main,
    settings,
    credits,
    exit,
    lastCredits
}
public class Menu : MonoBehaviour
{
    [Header("MenuCanvas")]
    public GameObject canvas;
    [Header("Buttons")]
    public GameObject startB;
    public GameObject settingsB;
    public GameObject creditsB;
    public GameObject exitB;
    public GameObject settingBackB;
    public GameObject creditsBackB;
    [Header("State")]
    public menuState state = menuState.main;
    [Header("Menus")]
    public GameObject mainO;
    public GameObject settingsO;
    public GameObject creditsO;
    public GameObject exitConfirmationO;
    public GameObject lastCreditsO;
    [Header("GameController")]
    public GameController controller;
    private bool internalEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }
    private void Awake()
    {
    }
    // Update is called once per frame
    void Update()
    {
        switch (this.state)
        {
            case menuState.main:
                //Debug.Log("estado main");
                mainO.SetActive(true);
                settingsO.SetActive(false);
                creditsO.SetActive(false);
                exitConfirmationO.SetActive(false);
                lastCreditsO.SetActive(false);
                break;
            case menuState.settings:
                mainO.SetActive(false);
                settingsO.SetActive(true);
                creditsO.SetActive(false);
                exitConfirmationO.SetActive(false);
                lastCreditsO.SetActive(false);
                break;
            case menuState.credits:
                mainO.SetActive(false);
                settingsO.SetActive(false);
                creditsO.SetActive(true);
                exitConfirmationO.SetActive(false);
                lastCreditsO.SetActive(false);
                break;
            case menuState.exit:
                exitConfirmationO.SetActive(true);
                break;
            case menuState.lastCredits:
                mainO.SetActive(false);
                settingsO.SetActive(false);
                creditsO.SetActive(false);
                exitConfirmationO.SetActive(false);
                lastCreditsO.SetActive(true);
                break;
        }    
    }

    public void toggleMenu(bool enabled)
    {
        if (internalEnabled != enabled)
        {
            this.internalEnabled = enabled;
            this.state = menuState.main;
            canvas.SetActive(enabled);
        }
    }

    public void LastCredits()
    {
        this.internalEnabled = enabled;
        this.state = menuState.lastCredits;
        canvas.SetActive(enabled);
    }
    public void credits()
    {
        this.state = menuState.credits;
    }
    public void goBack()
    {
        this.state = menuState.main;
    }
    public void start()
    {
        toggleMenu(false);
        controller.state = states.playing;
    }
    public void settings()
    {
        this.state = menuState.settings;
    }
    public void exit()
    {
        this.state = menuState.exit;
    }

    public void reallyCloseThis()
    {
        Application.Quit();
    }
}
