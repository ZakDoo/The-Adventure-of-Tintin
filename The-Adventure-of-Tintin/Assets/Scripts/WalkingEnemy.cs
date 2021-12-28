using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(this.isFacingRight==true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag=="Wall")
        {
            flip();
        }
        else if(collider.tag=="Enemy")
        {
            flip();
        }
        else if(collider.tag=="Ground")
        {
            flip();
        }
        if(collider.tag=="Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            flip();
        }
    }
}
