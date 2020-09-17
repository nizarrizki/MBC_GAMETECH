using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingground : MonoBehaviour
{
    private Vector3 posA;

    private Vector3 posB; 

    private Vector3 nexPos;

    private bool moving;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;


    void Start(){
        
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nexPos = posB;
    }

    void Update(){
        Move();
    }
      
    private void Move(){
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nexPos, speed * Time.deltaTime);
        
        if(Vector3.Distance(childTransform.localPosition,nexPos) <= 0.1){
            ChangeDestination();
        }
    }
    private void ChangeDestination(){
        nexPos = nexPos != posA ? posA : posB; 
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.layer = 9;
            other.transform.SetParent(childTransform);

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.gameObject.layer = 0;
        other.transform.SetParent(null);
    }
}
