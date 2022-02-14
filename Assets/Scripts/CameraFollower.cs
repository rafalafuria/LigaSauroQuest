using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform player;
    public float smooth = 0.5f;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(0.5f, 05f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition2d = Vector2.zero;

        newPosition2d.x = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocity.x, smooth);
        newPosition2d.y = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocity.y, smooth);


        Vector3 newPosition = new Vector3(newPosition2d.x, newPosition2d.y, transform.position.z);

        transform.position = Vector3.Slerp(transform.position, newPosition, Time.time);
    }
}
