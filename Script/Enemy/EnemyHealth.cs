using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float enemyMaxHealth;

    public GameObject enemyDeathFX;
    public Slider enemySlider;

    public static float currentHealth;
    public bool drops;
    public GameObject theDrop;
    public GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemyMaxHealth;

        enemySlider.maxValue = currentHealth;

        enemySlider.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void addDamage(float damage)
    {
        enemySlider.gameObject.SetActive(true);

        currentHealth -= damage;

        enemySlider.value = currentHealth;
        
        if (currentHealth <= 0)
        {
            MakeDead();
        }
    }

    void MakeDead()
    {
        //Destroy(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        finish.SetActive(true);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}
