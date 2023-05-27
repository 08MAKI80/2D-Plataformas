using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countdown; 
    public float timeToTP, countdownToTP;

    public float bossHealth, currentHealth;

    public Image healthImg;

    private void Start()
    { 
        transform.position = transforms[1].position;
        countdown = timeToShoot;
        countdownToTP = timeToTP;
        bossHealth = GetComponent<Enemy>().maxhealth;
    }

    private void Update()
    {

        countdown -= Time.deltaTime;
        countdownToTP -= Time.deltaTime;

        if (countdown <= 0f)
        {
            ShootPlayer();
            countdown = timeToShoot;
           
        }   
        if(countdownToTP <= 0)
        {
            countdownToTP = timeToTP;
            Teleport();
        }
        DamageBoss();
        BossScale();
    }

    

    public void ShootPlayer()
    {
            GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void Teleport() 
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
    }

    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healtpoint;
        healthImg.fillAmount = currentHealth / bossHealth;

    }

    private void OnDestroy()
    {
        BossUI.instance.BossDesactivator();
    }

    public void BossScale()
    {
        if(transform.position.x < PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    IEnumerator BossDefeated()
    {
        Vector2 originalSpeed = PlayerController.instance.GetComponent<Rigidbody2D>().velocity;
        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, PlayerController.instance.GetComponent<Rigidbody2D>().velocity.y);
        PlayerController.instance.enabled = false;
        yield return new WaitForSeconds(3);
        PlayerController.instance.enabled = true;
        PlayerController.instance.GetComponent<Rigidbody2D>().velocity = originalSpeed;
    }
}
