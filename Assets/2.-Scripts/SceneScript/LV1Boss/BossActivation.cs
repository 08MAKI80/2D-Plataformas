using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{

    public GameObject boss;

    private void Start()
    {
        boss.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossActivator();
            AudioManager.instance.PlayAudio(AudioManager.instance.bossEncounter);
            AudioManager.instance.StopAudio(AudioManager.instance.bGMusic);
            AudioManager.instance.PlayAudio(AudioManager.instance.bossBGMusic);
            StartCoroutine(WaitForBoss());
        }
    }

    IEnumerator WaitForBoss()
    {
        var currentSpeed = PlayerController.instance.speed;
        PlayerController.instance.speed = 0;
        boss.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerController.instance.speed = currentSpeed;
        Destroy(gameObject);
    }
}
