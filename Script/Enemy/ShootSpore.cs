using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShootSpore : MonoBehaviour
{

    public GameObject theProjectile;
    public float shootTime;
    public int chanceShoot;
    public Transform shootFrom;

    float nextShootTime;
    Animator cannonAnim;

    // Start is called before the first frame update
    void Start()
    {
        cannonAnim = GetComponentInChildren<Animator>();
        nextShootTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player" && nextShootTime < Time.time)
        {
            nextShootTime = Time.time + shootTime;
            if(UnityEngine.Random.Range(0, 10) >= chanceShoot)
            {
                Instantiate(theProjectile, shootFrom.position, quaternion.identity);
                cannonAnim.SetTrigger("canonShoot");
            }
        }
    }
}
