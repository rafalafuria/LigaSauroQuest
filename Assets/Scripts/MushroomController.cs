using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public AudioClip collectSfx;
    private float lifeTime;
    public float maxLifeTime;
    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 5;
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectSfx, transform.position);
            ScoreScript.scoreValue += 10;
            Destroy(gameObject);
        }
    }
}
