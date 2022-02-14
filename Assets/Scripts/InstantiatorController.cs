using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorController : MonoBehaviour
{
    public GameObject[] objects;
    private bool isLeft = true;
    public float velocity = 5f;
    public float maxDelay;

    public float instantiatorTime = 5f;
    public float instantiatorDelay = 3f;

    private float movementTime = 0f;
    public int minRandomValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", instantiatorTime, instantiatorDelay);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Spawn()
    {
        int index = Random.Range(minRandomValue, objects.Length);
        Instantiate(objects[index], transform.position, objects[index].transform.rotation);
    }

    void Movement()
    {
        movementTime += Time.deltaTime;
        if (movementTime <= maxDelay)
        {
            if (isLeft)
            {
                transform.Translate(Vector2.right * velocity * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.Translate(Vector2.right * velocity * Time.deltaTime);
                transform.eulerAngles = new Vector2(0, 180);
            }
        }
        else
        {
            isLeft = !isLeft;
            movementTime = 0;
        }
    }
}
