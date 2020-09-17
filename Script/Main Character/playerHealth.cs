using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public float fullHealth;
    public GameObject deathFX;
    public AudioClip playerHurt;
    public AudioClip playerDie;

    public GameObject gameOverCanvas;
    public GameObject theGameManager;
    public GameObject buttonToDissable;
    public GameObject pauseToDissable;

    AudioSource playerAS;

    //playerHUDHealth
    public Slider healthSlider;
   // public Image DamageScreen;
    public Text gameOverScreen;

    bool damaged = false;
    Color damagedColor = new Color(255f, 255f, 255f, 0.5f);
    float smoothColor = 4f;
    float currentHealth;

    Mola_MovementButton controlMovement;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = fullHealth;

        controlMovement = GetComponent<Mola_MovementButton>();

        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;

        playerAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (damaged)
        {
            DamageScreen.color = damagedColor;
        }
        else
        {
            DamageScreen.color = Color.Lerp(DamageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
      */  damaged = false;
    }

    public void addDamage(float damage) {
        if (damage <= 0) return;
        currentHealth -= damage;

       // playerAS.clip = playerHurt;
      //  playerAS.Play();
       playerAS.PlayOneShot(playerHurt);

        healthSlider.value = currentHealth;
        damaged = true;

        if(currentHealth <= 0)
        {
    
            makeDead();
        }
    }
    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth)
            currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        buttonToDissable.SetActive(false);
        pauseToDissable.SetActive(false);

        gameOverCanvas.SetActive(true);

        AudioSource.PlayClipAtPoint(playerDie, transform.position);
       // playerAS.PlayOneShot(playerDie);
        Instantiate(deathFX, transform.position, transform.rotation);
       
        Destroy(gameObject);
      //  DamageScreen.color = damagedColor;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");
        theGameManager.SetActive(true);
        
    }

}
