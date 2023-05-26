using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotions : MonoBehaviour
{
    public float manaToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealt>().mana += manaToGive;
            Destroy(gameObject);
        }
    }
}
