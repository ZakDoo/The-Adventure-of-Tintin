using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogControler : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
   
    public KeyCode spacebar;
    public KeyCode Left;
    public KeyCode Right;
    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask whatIsGround;
    private bool grounded;

    private Animator anim;

    public AudioClip jump1;

    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);

        
    }

    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        AudioManager.instance.PlaySingle(jump1);
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
