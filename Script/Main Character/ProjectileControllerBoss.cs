using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControllerBoss : MonoBehaviour
{
    public float bubbleSpeed;
    Rigidbody2D TheRB;
    // Start is called before the first frame update
    void Awake()
    {
        TheRB = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            TheRB.AddForce(new Vector2(2, 0) * bubbleSpeed, ForceMode2D.Impulse);
        }
        else
        {
            TheRB.AddForce(new Vector2(3, 0) * bubbleSpeed, ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void removeForce()
    {
        TheRB.velocity = new Vector2(0, 0);
    }
}
