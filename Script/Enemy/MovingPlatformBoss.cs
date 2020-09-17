using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBoss : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public static float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = EnemyBos.turretSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }
    void FixedUpdate()
    {
        speed = EnemyBos.turretSpeed;
    }
}
