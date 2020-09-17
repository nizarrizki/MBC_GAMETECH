using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gerak : MonoBehaviour {

    // Use this for initialization
    public int kecepatan, kekuatanlompat, pindah;
    public bool balik;
    Rigidbody2D lompat;
 

    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;
    Animator anim;
	void Start () {
        
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Run", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = -1;
        }else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Run", true);
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            pindah = 1;
        }
        else
        {
            anim.SetBool("Run", false);
        }
        



        if (pindah>0 && !balik){
            balikbadan();
        }else if (pindah<0 && balik){
            balikbadan();
        }
        
	}
   

    //void OnTriggerEnter2D(Collider2D col){
        //if(col.gameObject.tag == "Grnd"){
           // Debug.Log("Do something here");
            //tanah=true;
       // }
    //}

    //void OnTriggerExit2D(Collider2D other)
   // {
       // if(other.gameObject.tag == "Grnd"){
        //    Debug.Log("Do something here");
        //    tanah=false;
       // }
   // }

    void balikbadan ()
    {
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }
       
}
