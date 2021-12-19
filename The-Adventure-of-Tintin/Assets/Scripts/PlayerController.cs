using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed; //Speed of the player
    public float jumpHeight; //Height of the player jump
    public bool isFacingRight; //check if the character is facing right
 
    public KeyCode spacebar;
    public KeyCode Left; //keyboard button to be declared in unity
    public KeyCode Right; //keyboard button to be declared in unity 
    public Transform groundCheck; //check if the player is touching the ground or not
    public float groundCheckRadius; //the radius of the checking

    public KeyCode Return;
    public Transform firepoint;
    public GameObject bullet;

    public LayerMask whatIsGround; //stores what is the ground to check on it
    private bool grounded; //check if the player is touching the ground

    private Animator anim; //controls the character's animation

    public AudioClip jump1;
    public AudioClip jump2;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseResume.paused)
        {


            if (Input.GetKeyDown(spacebar) && grounded)
            {
                Jump();
            }

            if (Input.GetKey(Left))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

                if (isFacingRight)
                {
                    flip();
                    isFacingRight = false;
                }

            }

            if (Input.GetKey(Right))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

                if (!isFacingRight)
                {
                    flip();
                    isFacingRight = true;
                }
            }

            if (Input.GetKeyDown(Return))
            {
                Shoot();
            }

            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)); //animation for the movement(walk)
            anim.SetBool("Grounded", grounded); //animation for jumping

        }

    }

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        AudioManager.instance.RandomizeSfx(jump1, jump2);
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }

}
