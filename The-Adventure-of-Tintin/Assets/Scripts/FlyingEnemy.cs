using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : EnemyController
{

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private Vector3 temp_Pos;

    public float moveSpeed;
    private PlayerController Player;

    // Start is called before the first frame update
    void Start()
    {
        temp_Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        temp_Pos.x += HorizontalSpeed;
        temp_Pos.y = Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = temp_Pos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            GoToNextScene();
            Destroy(this.gameObject);
        }
    }
    public void GoToNextScene()
    {
        Application.LoadLevel(5);
    }
}
