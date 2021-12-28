using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public int health = 100;
    public int lives = 3;

    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;

    private SpriteRenderer spriteRenderer;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    public int coinsCollected = 0;

    public AudioClip GameOverSound;

    public Text scoreUI;
    public Slider healthUI;
    public Gradient gradient;
    public Image fill;
    public Text livesUI;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isImmune==true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if(immunityTime>=immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;

                Debug.Log("Immunity has ended");
            }
        }

        scoreUI.text = "" + coinsCollected;

        livesUI.text = "" + lives;

        healthUI.value = health;

        fill.color = gradient.Evaluate(healthUI.normalizedValue);
    }

    void SpriteFlicker()
    {
        if(this.flickerTime<this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if(this.flickerTime>=this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        if(this.isImmune==false)
        {
            this.health = this.health - damage;
            if(this.health<0)
            {
                this.health = 0;
            }
            if(this.lives>0 && this.health==0)
            {
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 100;
                this.lives--;
            }
            else if(this.lives==0 && this.health==0)
            {
                new NavigationController().GoToGameOverScene();
                Debug.Log("Game Over");
                AudioManager.instance.PlaySingle(GameOverSound);
                AudioManager.instance.musicSource.Stop();
                Destroy(this.gameObject);
            }

            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        }

        PlayHitReaction();
    }

    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void CollectCoin(int coinValue)
    {
        this.coinsCollected = this.coinsCollected + coinValue;
    }

    public void heal(int healValue)
    {
        if (health < 100)
        {
            this.health = this.health + healValue;
            if(health>100)
            {
                health = 100;
            }
            Debug.Log("Player Health: " + this.health.ToString());
        }
    }

}
