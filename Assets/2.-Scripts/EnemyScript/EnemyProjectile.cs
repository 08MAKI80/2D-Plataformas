using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    public GameObject projectile;
    public GameObject projectileToDestroy;
    public float timeToshoot;
    public float shootCooldown;
    public float timeDestroyProjectile;
    public float destroyCooldown;
    public bool freqShooter;
    public bool watcher;
    

    // Start is called before the first frame update
    void Start()
    {
        destroyCooldown = timeDestroyProjectile;
    }

    // Update is called once per frame
    void Update()
    {

        if (freqShooter)
        {
            shootCooldown -= Time.deltaTime;

            if (shootCooldown < 0)
            {
                projectileToDestroy=Shoot();
                
                if (destroyCooldown < 0)
                {
                    Destroy(projectileToDestroy);
                    destroyCooldown = timeDestroyProjectile;
                }
            }
        }
        if(watcher)
        {
            shootCooldown -= Time.deltaTime;
            destroyCooldown -= Time.deltaTime;
            if (destroyCooldown < 0)
            {
                Destroy(projectileToDestroy);
                destroyCooldown = timeDestroyProjectile;
            }
            
        }
        

    }

    public GameObject Shoot()
    {
        GameObject stone = Instantiate(projectile, transform.position, Quaternion.identity);

        if (transform.localScale.x < 0)
        {
            stone.GetComponent<Rigidbody2D>().AddForce(new Vector2(125f, 0f), ForceMode2D.Force);
        }
        else
        {
            stone.GetComponent<Rigidbody2D>().AddForce(new Vector2(-125f, 0f), ForceMode2D.Force);
        }

        shootCooldown = timeToshoot;

        return stone;
    }
}
