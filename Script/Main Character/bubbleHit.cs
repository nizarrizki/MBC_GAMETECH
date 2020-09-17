using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleHit : MonoBehaviour
{

    public float weaponDamage;

    Projectile_Controller myPc;

    public GameObject explossionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        myPc = GetComponentInParent<Projectile_Controller>();
    }

    // Update is called once per frame


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPc.removeForce();
            Instantiate(explossionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if(other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage (weaponDamage);

            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shootable"))
        {
            myPc.removeForce();
            Instantiate(explossionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.tag == "Enemy")
            {
                EnemyHealth hurtEnemy = other.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.addDamage(weaponDamage);

            }
        }
    }
}
