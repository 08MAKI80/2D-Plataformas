using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    public int cashTogive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BankAccount.instance.Money(cashTogive);
            AudioManager.instance.PlayAudio(AudioManager.instance.coin);
            Destroy(gameObject); 
        }
    }
}
