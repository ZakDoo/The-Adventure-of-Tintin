using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkHeal : MonoBehaviour
{

    public int healValue = 30;

    public AudioClip drink;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().heal(healValue);

            AudioManager.instance.PlaySingle(drink);
            Destroy(this.gameObject);
        }
    }
}
