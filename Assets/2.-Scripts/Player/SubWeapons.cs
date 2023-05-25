using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int bulletCost;
    public int MagicCost;
    public GameObject bullet;
    public GameObject Spell;
    public float timeToShoot;
    public float shootCooldown;
    public float timeToCastSpell;
    public float spellCooldown;
    public GameObject projectileToDestroy;

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
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (Input.GetButtonDown("Fire2") && bulletCost <= Bullets.instance.bulletsAmount)
            {
                Bullets.instance.SubItem(-bulletCost);

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
        }

        //casteo y disparo de hechizo
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            if (Input.GetButtonDown("Fire2") && MagicCost <= PlayerHealt.instance.mana)
            {


                PlayerHealt.instance.mana -= MagicCost;




            }


        }
    }
}
