using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatScript : MonoBehaviour
{
    public AudioClip collectSfx;
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            {
                AudioSource.PlayClipAtPoint(collectSfx, transform.position);
                GameControlScript.health += 1;
                ScoreScript.scoreValue += 15;
                Destroy(gameObject);
            }
        }   
    }
    
}