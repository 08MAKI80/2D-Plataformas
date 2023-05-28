using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public float mana;
    public float maxMana;
    public float swordDamage;
    public float spellDamage;
    public float bulletDamage;
    //public float stamina;
    //public float maxstamina;
    public Image healthImage;
    public Image manaImage;
    public float inmunityTime;
    private bool isInmune;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Rigidbody2D rb;

    public GameObject gameOver;

    public static PlayerHealt instance;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.gameOverSound.Stop();
        gameOver.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        health = maxHealth;
        mana = maxMana;
        //stamina = maxstamina;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.fillAmount = health / maxHealth;
        manaImage.fillAmount = mana / maxMana;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        else if(mana> maxMana)
        {
            mana = maxMana;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("EnemiesProjectiles")) && !isInmune)
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.playerHit);
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

            if(collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
               rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }

            if(health <= 0)
            {
                // aparecer pantalla de game over
                Time.timeScale = 0;
                gameOver.SetActive(true);
                AudioManager.instance.bossBGMusic.Stop();
                AudioManager.instance.bGMusic.Stop();
                AudioManager.instance.swordSlash.Stop();
                AudioManager.instance.fireBall.Stop();
                AudioManager.instance.shot.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.gameOverSound);
                print("Player Dead");
            }
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(inmunityTime);
        sprite.material = material.original;
        isInmune = false;
    }
}
