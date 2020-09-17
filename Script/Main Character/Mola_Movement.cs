using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mola_Movement : MonoBehaviour
{

    // Use this for initialization
    public int Speed, Jump, FlipIndicator;
    public bool FacingRight;
    Rigidbody2D TheRB;
    public bool LButton, RButton;
    Animator anim;
    void Start()
    {

        TheRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
            FlipIndicator = -1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Run", true);
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
            FlipIndicator = 1;
        }
        else
        {
            anim.SetBool("Run", false);
        }

        if (FlipIndicator > 0 && !FacingRight)
        {
            Flip();
        }
        else if (FlipIndicator < 0 && FacingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }

    public void LeftButton()
    {
        LButton = true;
    }

}

