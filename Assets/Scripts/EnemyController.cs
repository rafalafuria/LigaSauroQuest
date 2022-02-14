using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject item;
    private bool isLeft = true;
    public float velocity = 5f;
    public float maxDelay;
    private float movementTime = 0f;

    public Transform initialVertex;
    public Transform finalVertex;
    public bool isTarget;

    private float maxDelayItem = 0.001f;
    private float poisonTime = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        RayCasting();
        Behaviors();
    }

    void RayCasting()
    {
        Debug.DrawLine(initialVertex.position, finalVertex.position, Color.red);
        isTarget = Physics2D.Linecast(initialVertex.position, finalVertex.position, 1 << LayerMask.NameToLayer("Player"));
    }

    void Behaviors()
    {
        if (isTarget)
        {
            if (poisonTime <= maxDelayItem)
            {
                poisonTime += Time.deltaTime;
                Instantiate(item, initialVertex.position, item.transform.rotation);
            }
        }
        else
        {
            poisonTime = 0;
        }
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
