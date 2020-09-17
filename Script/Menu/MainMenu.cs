using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
//using System.Runtime.Hosting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public Button Level2Button, Level3Button;
    int levelPassed;

     void Start()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        Level2Button.interactable = false;
        Level3Button.interactable = false;

        switch (levelPassed)
        {
            case 1:
                Level2Button.interactable = true;
                break;
            case 2:
                Level2Button.interactable = true;
                Level3Button.interactable = true;
                break;
        }
    }
    public void LoadScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void QuitMenu () 
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}

