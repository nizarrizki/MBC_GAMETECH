using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float alliveTime;

    // Start is called before the first frame update
    void Awake()
    {

        Destroy(gameObject, alliveTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
