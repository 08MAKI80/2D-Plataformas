using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectilesWOGDestroyer : MonoBehaviour
{
    public float timeToDestroy;
    public float destroyCooldown;
    // Start is called before the first frame update
    void Start()
    {
        destroyCooldown = timeToDestroy;
    }

    // Update is called once per frame
    void Update()
    {
        destroyCooldown -= Time.deltaTime;
        if (destroyCooldown < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pared") || collision.CompareTag("Player") || collision.CompareTag("Suelo"))
        {
            Destroy(gameObject);
        }
    }
}
