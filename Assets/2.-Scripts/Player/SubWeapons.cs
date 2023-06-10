using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int bulletCost;
    public float MagicCost;
    public GameObject bullet;
    public GameObject spell;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        //Disparar Balas
        if (((Input.GetButtonDown("Fire2") && Input.GetAxisRaw("Vertical") > 0) || Input.GetButtonDown("Fire3Gamepad")) && bulletCost <= Bullets.instance.bulletsAmount && !PauseMenu.instance.isPaused)
        {
                Bullets.instance.SubItem(-bulletCost);
                AudioManager.instance.PlayAudio(AudioManager.instance.shot);
                GameObject subItem = Instantiate(bullet, transform.position, Quaternion.identity);


                if (transform.localScale.x < 0)
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f), ForceMode2D.Force);
                }
                else
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f), ForceMode2D.Force);
                }

            }
        

        //casteo y disparo de hechizo
            if (((Input.GetButtonDown("Fire2") && Input.GetAxisRaw("Vertical") < 0) || Input.GetButtonDown("Fire2Gamepad")) && MagicCost <= PlayerHealt.instance.mana && !PauseMenu.instance.isPaused)
            {


                PlayerHealt.instance.mana -= MagicCost;
                AudioManager.instance.PlayAudio(AudioManager.instance.fireBall);
                GameObject subItem = Instantiate(spell, transform.position, Quaternion.identity);


                if (transform.localScale.x < 0)
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-500f, 0f), ForceMode2D.Force);
                }
                else
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(500f, 0f), ForceMode2D.Force);
                }


            }
    }
}
