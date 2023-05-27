using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public AudioMixer music, effects;

    public AudioSource bossDeath, bossEncounter, bossHit, coin, enemyDeath, fireBallBoss, fireBall,
        item, jump, playerHit, shot, skeletonHit, swordSlash, walk, bGMusic, bossBGMusic;


    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayAudio(bGMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
