using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    int coinValue = 1;

    public AudioClip coinSound;

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
        if(other.name=="Player")
        {
            FindObjectOfType<PlayerStats>().CollectCoin(coinValue);
            AudioManager.instance.PlaySingle(coinSound);
            Destroy(this.gameObject);
        }
    }
}
