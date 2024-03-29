using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotions : MonoBehaviour
{

    public int healthToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.item);
            collision.GetComponent<PlayerHealt>().health += healthToGive;
            Destroy(gameObject);
        }
    }
}
