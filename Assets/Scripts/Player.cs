using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocity;
    public Transform player;
    private Animator animator;
    public bool isGrounded;
    public float force;
    public float jumpTime = 0.50f;
    public float jumpDelay = 0.50f;
    public bool jumped;
    public Transform ground;
    public AudioClip winSfx;
    public GameControlScript gameControlScript;

    //mobile joystick
    public Joystick joystick;
    //public JoyButtonScript joyButton;

    // Start is called before the first frame update
    void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    //Movement of player
    void Movement()
    {
        //verify if the game object is in the same position of the platform 
        isGrounded = Physics2D.Linecast(this.transform.position, ground.position, 1 << LayerMask.NameToLayer("Platform"));

        //sets a variable for the animator whem right or left is pressed
        //animator.SetFloat("run", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("run", Mathf.Abs(joystick.Horizontal));

        //movement for keyboard 
        //if (Input.GetAxisRaw("Horizontal") > 0)
        //movement for mobile
        if (joystick.Horizontal > 0)
        {
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
            //new vector for turn the sprite
            transform.eulerAngles = new Vector2(0, 0);
        }

        //movement for keyboard
        //if (Input.GetAxisRaw("Horizontal") < 0)
        //movement for mobile
        if (joystick.Horizontal < 0)
        {
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
            //new vector for turn the sprite 180 degrees for left movement.
            transform.eulerAngles = new Vector2(0, 180);
        }
        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f && isGrounded && !jumped)
        {
            var rigidbody = GetComponent<Rigidbody>();
            GetComponent<Rigidbody2D>().AddForce(transform.up * force);
            //rigidbody.velocity = new Vector3(joystick.Horizontal * 100f, rigidbody.velocity.y, joystick.Vertical * 100f);
            jumpTime = jumpDelay;
            animator.SetTrigger("jump");
            jumped = true;
        }
        jumpTime -= Time.deltaTime;
        if (jumpTime <= 0 && isGrounded && jumped)
        {
            animator.SetTrigger("ground");
            jumped = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Sign")
        {
            gameControlScript.CompleteLevel();
            AudioSource.PlayClipAtPoint(winSfx, transform.position);
        }
        if (col.gameObject.name == "Water")
        {
            ScoreScript.scoreValue -= 20;
            SceneManager.LoadScene("Level1");
        }
    }
}
