using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickUp : MonoBehaviour
{
    public float healthAmount;


    public AudioClip hpPickUpSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            playerHealth theHealth = other.gameObject.GetComponent<playerHealth>();
            theHealth.addHealth(healthAmount);
            AudioSource.PlayClipAtPoint(hpPickUpSound, transform.position);
            Destroy(gameObject);
        }
    }
}
