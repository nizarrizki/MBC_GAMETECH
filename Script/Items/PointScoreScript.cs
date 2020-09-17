using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScoreScript : MonoBehaviour
{

    public AudioClip claimCoin;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            ScoreCoinScript.score += 1;
            FinishLine.highscore += 1;
            AudioSource.PlayClipAtPoint(claimCoin, transform.position);
            Destroy(gameObject);
        }
    }
}