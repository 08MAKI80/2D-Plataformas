using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{

    public int bulletCost;

    public GameObject bullet;

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
        if(Input.GetAxisRaw("Vertical")>0)
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
        
    }
}
