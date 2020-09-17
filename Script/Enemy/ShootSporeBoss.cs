using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
public class ShootSporeBoss : MonoBehaviour
{

    //public GameObject theProjectile;
    public float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;
    private Transform player;
    public Transform guntip;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
       
        

            if (other.tag == "Player" && timeBtwShots <= 0)
            {
                Instantiate(projectile, guntip.position, quaternion.identity);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        
    }


}
