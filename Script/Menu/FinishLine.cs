using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLine : MonoBehaviour
{
    public GameObject finish;
    public AudioSource audioSource;
    public static int highscore;
    int levelPassed;
    public GameObject stars1, stars2, stars3;
    public int nextToLevel;

    public GameObject confetiFX;

    Animator FinishAnim;

    // Start is called before the first frame update
    void Start()
    {
        FinishAnim = GetComponent<Animator>();
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
    }

    void Update()
    {
       // GetComponent<Text>().text = highscore.ToString();
        if (highscore >= 5 && highscore <= 10)
        {
           //FinishAnim.SetBool("1S", true);
            stars1.SetActive(true);
        }
        if (highscore >= 11  && highscore <= 15)
        {
           // FinishAnim.SetBool("2S", true);
            stars2.SetActive(true);
        }
        if (highscore >= 16)
        {
           // FinishAnim.SetBool("3S", true);
            stars3.SetActive(true);

        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            finish.SetActive(true);
            PlayerPrefs.SetInt("LevelPassed", nextToLevel);
            
           Time.timeScale = 0f;

            audioSource.Play();
        }
    }
}
