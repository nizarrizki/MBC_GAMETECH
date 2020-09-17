using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Mathematics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Mola_MovementButton : MonoBehaviour
{
    Rigidbody2D TheRB;
    Animator TheAnim;
    public float TheSpeed;
    private float dirX;
    private bool FacingRight = true;
    public Vector3 LocalScale;
    
    public float TheJump;
    
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;

    public float maxSpeed;

    public GameObject dustEffect;
    private bool spawnDust;
    private AudioSource source;
    public AudioClip landingSound;

    private AudioSource suaraLompat;
    public AudioClip jumpSound;


    //shootVAR
    public Transform guntip;
    public GameObject bullet;
    float fireRate = 1.08f;
    float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        suaraLompat = GetComponent<AudioSource>();
        source = GetComponent<AudioSource>();
        TheRB = GetComponent<Rigidbody2D>();
        TheAnim = GetComponent<Animator>();
        LocalScale = transform.localScale;

        FacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (grounded == true)
        {
            if(spawnDust == true)
            {
                source.clip = landingSound;
                source.Play();
                Instantiate(dustEffect, groundCheck.position, quaternion.identity);
                spawnDust = false;
            }
        }
        else
        {
            spawnDust = true;
        }
        //movement keyboard&& TheRB.velocity.y == 0
        if (grounded && CrossPlatformInputManager.GetButtonDown("Jump") )
        {
            suaraLompat.clip = jumpSound;
            suaraLompat.Play();
            grounded = false;
            TheAnim.SetBool("isGrounded", grounded);
            TheRB.AddForce(new Vector2(0, jumpHeight));
        }
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            
            BubbleGun();
        }

        //movement button android
        /*dirX = CrossPlatformInputManager.GetAxis("Horizontal") * TheSpeed * Time.deltaTime;

        if (grounded && CrossPlatformInputManager.GetButtonDown("Jump") && TheRB.velocity.y == 0) {
           
            grounded = false;
            TheRB.AddForce(Vector2.up * TheJump);
        }
        
        if (Mathf.Abs(dirX) > 0 && TheRB.velocity.y == 0 && grounded) { 
        TheAnim.SetBool("Run", true);
        } else
        {
            TheAnim.SetBool("Run", false);
        }
        if (TheRB.velocity.y == 0 && grounded) {
            TheAnim.SetBool("Jump", false);
            TheAnim.SetBool("Landing", false);
            TheAnim.SetBool("Takeof", false);
       
        }
        if (TheRB.velocity.y > 0 && grounded)
        {
            TheAnim.SetBool("Takeof", true);
            TheAnim.SetBool("Jump", true);
        }
        if (TheRB.velocity.y < 0 && grounded)
        {
            TheAnim.SetBool("Takeof", false);
            TheAnim.SetBool("Jump", false);
           
        }*/
    }
    void FixedUpdate ()
    {
        /* TheRB.velocity = new Vector2(dirX, TheRB.velocity.y);
         grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
         TheAnim.SetBool("Landing", grounded); */

        //dari casinis play
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        TheAnim.SetBool("isGrounded", grounded);

        TheAnim.SetFloat("verticalSpeed", TheRB.velocity.y);

        float move = CrossPlatformInputManager.GetAxis("Horizontal");
        TheAnim.SetFloat("speed", Mathf.Abs(move));

        TheRB.velocity = new Vector2(move * maxSpeed, TheRB.velocity.y);

        if (move > 0 && !FacingRight)
        {
            
            flip();
        }
        else if(move < 0 && FacingRight)
        {
            
            flip();
        }
    }

    void flip()
    {
        FacingRight = !FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    /*void LateUpdate()
    {
      if (dirX > 0)
        {
            FacingRight = true;
            TheAnim.SetBool("Run", true);
            transform.Translate(Vector2.right * TheSpeed * Time.deltaTime);
        } else if (dirX < 0)
        {
            TheAnim.SetBool("Run", true);
            FacingRight = false;
            transform.Translate(Vector2.left * TheSpeed * Time.deltaTime);
        } if (((FacingRight) && (LocalScale.x < 0)) || ((!FacingRight) && (LocalScale.x > 0)))
        {
            LocalScale.x *= -1;
        }
        transform.localScale = LocalScale;
    }*/

    void BubbleGun()
    {
        
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            TheAnim.SetTrigger("Gun");
            if (FacingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            }else if (!FacingRight)
            {
                Instantiate(bullet, guntip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
}
