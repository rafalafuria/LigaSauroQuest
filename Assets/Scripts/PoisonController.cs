using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonController : MonoBehaviour
{
    public int point = 2;
    public float maxLifeTime;
    public float lifeTime;
    public AudioClip damageSfx;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime >= maxLifeTime)
        {
            Destroy(gameObject);
            lifeTime = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            {
                AudioSource.PlayClipAtPoint(damageSfx, transform.position);
                GameControlScript.health -= 1;
                ScoreScript.scoreValue -= 5;
                Destroy(gameObject);
            }
        }
    }
}
