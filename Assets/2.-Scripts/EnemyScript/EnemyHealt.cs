using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealt : MonoBehaviour
{
    Enemy enemy;
    public bool isDamaged;
    public GameObject deatEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        material = GetComponent<Blink>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Arma") && !isDamaged)
        {
            enemy.healtpoint -= PlayerHealt.instance.swordDamage;
            EnemyDamaged(collision);
        }
        else if (collision.CompareTag("Bullet") && !isDamaged)
        {
            enemy.healtpoint -= PlayerHealt.instance.bulletDamage;
            EnemyDamaged(collision);
        }
        else if (collision.CompareTag("Spell") && !isDamaged)
        {
            enemy.healtpoint -= PlayerHealt.instance.spellDamage;
            EnemyDamaged(collision);
        }
    }

    public void EnemyDamaged(Collider2D collision)
    {
        if (collision.transform.position.x < transform.position.x)
        {
            rb.AddForce(new Vector2(enemy.knocbackForceX, enemy.knocbackForceY), ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(new Vector2(-enemy.knocbackForceX, enemy.knocbackForceY), ForceMode2D.Force);
        }

        StartCoroutine(Damager());

        if (enemy.healtpoint <= 0)
        {
            Instantiate(deatEffect, transform.position, Quaternion.identity);
            ExperienceScript.instance.expModifier(GetComponent<Enemy>().ExpToGive);
            Destroy(gameObject);
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.original;
    }
}
