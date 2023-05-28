using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;

    public AudioSource bossDeath, bossEncounter, bossHit, coin, enemyDeath, fireBallBoss, fireBall,
        item, jump, playerHit, shot, skeletonHit, swordSlash, walk, bGMusic, bossBGMusic,gameOverSound;

    public static AudioManager instance;

    [Range(-50,0)]
    public float musicVol, effectsVol;
    public Slider musicSlider, effectsSlider;

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
        musicSlider.value = musicVol;
        effectsSlider.value = effectsVol;

        musicSlider.minValue = -70;
        musicSlider.maxValue = 0;
        effectsSlider.minValue = -70;
        effectsSlider.maxValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MusicVolume();
        EffectsVolume();
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
        
    }

    public void StopAudio(AudioSource audio)
    {
        audio.Stop();
    }

    public void MusicVolume()
    {
        musicMixer.SetFloat("musicVolume", musicSlider.value);
    }
    public void EffectsVolume()
    {
        effectsMixer.SetFloat("effectsVolume", effectsSlider.value);
    }
}
