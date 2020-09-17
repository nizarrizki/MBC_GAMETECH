using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject InGameMenuUI;
    public GameObject buttonOff;

    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Pause"))
        {
            Pause();
        }

        if (CrossPlatformInputManager.GetButtonDown("Restart"))
        {
            Restart();
        }

        if (CrossPlatformInputManager.GetButtonDown("Quit"))
        {
            Quit();
        }
        if (CrossPlatformInputManager.GetButtonDown("Home"))
        {
            Home();
        }
    }
    public void Home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Select Level");
    }

    public void Pause()
    {
        InGameMenuUI.SetActive(true);
        buttonOff.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;

    }

    public void Restart()
    {
        ScoreCoinScript.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        ScoreCoinScript.score = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Select Level");
    }

}
