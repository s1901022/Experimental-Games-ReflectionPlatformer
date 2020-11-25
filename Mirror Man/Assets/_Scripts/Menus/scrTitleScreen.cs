using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scrTitleScreen : MonoBehaviour
{
    private Canvas m_UI;
    private Image UI_Title;
    private Image UI_Title2;
    private Image UI_ItemPlay;
    private Image UI_ItemAbout;
    private Image UI_ItemOptions;

    private bool m_loadedUI;
    private int m_currentSelection;
    enum MenuStates
    {
        StartGame,
        Options,
        About
    }
    private MenuStates m_menuState;

    public string sceneToLoad;

    // Start is called before the first frame update
    void Start()
    {
        m_UI = GetComponent<Canvas>();

        //UI Elements
        UI_Title = m_UI.transform.Find("Title").GetComponent<Image>();
        UI_Title2 = UI_Title.transform.Find("Text").GetComponent<Image>();
        UI_ItemPlay = m_UI.transform.Find("Play").GetComponent<Image>();
        UI_ItemAbout = m_UI.transform.Find("About").GetComponent<Image>();
        UI_ItemOptions = m_UI.transform.Find("Options").GetComponent<Image>();
        ResetColour(0f);

        //Variables
        m_currentSelection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_loadedUI)
        {
            m_loadedUI = true;
        }
        if (m_loadedUI)
        {
            if (UI_Title.color.a < 1.0f)
            {
                UI_Title.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, UI_Title.color.a + 0.01f);
                UI_Title2.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, UI_Title.color.a + 0.01f);
                UI_ItemPlay.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, UI_Title.color.a + 0.01f);
                UI_ItemAbout.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, UI_Title.color.a + 0.01f);
                UI_ItemOptions.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, UI_Title.color.a + 0.01f);
            }

            Menu();
        }
        if (Input.GetKeyDown(KeyCode.Space) && m_loadedUI == true && UI_Title.color.a >= 1f)
        {
            ResetColour(0f);
            m_menuState = MenuStates.StartGame;
            m_currentSelection = 0;
            m_loadedUI = false;
        }
    }

    void Menu()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ResetColour(1f);
            m_currentSelection -= 1;
            if (m_currentSelection < 0)
            {
                m_menuState = MenuStates.About;
                m_currentSelection = 2;
            }
            else
            {
                m_menuState -= 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ResetColour(1f);
            m_currentSelection += 1;
            if (m_currentSelection > 2)
            {
                m_menuState = MenuStates.StartGame;
                m_currentSelection = 0;
            }
            else
            {
                m_menuState += 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ResetColour(1f);
        }
        switch (m_menuState)
        {
            case MenuStates.StartGame:
                UI_ItemPlay.color = new Color(UI_Title.color.r - 0.5f, UI_Title.color.g, UI_Title.color.b, 1f);
                //Start game
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    SceneManager.LoadScene(sceneToLoad);
                }
                //To be replaced with save select or level select in future
                break;
            case MenuStates.Options:
                UI_ItemOptions.color = new Color(UI_Title.color.r - 0.5f, UI_Title.color.g, UI_Title.color.b, 1f);
                //To be Implemented
                break;
            case MenuStates.About:
                UI_ItemAbout.color = new Color(UI_Title.color.r - 0.5f, UI_Title.color.g, UI_Title.color.b, 1f);
                //To be implemented
                break;
        }  
    }

    void ResetColour(float a_val)
    {
        UI_Title.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, a_val);
        UI_Title2.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, a_val);
        UI_ItemPlay.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, a_val);
        UI_ItemAbout.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, a_val);
        UI_ItemOptions.color = new Color(UI_Title.color.r, UI_Title.color.g, UI_Title.color.b, a_val);
    }
}
