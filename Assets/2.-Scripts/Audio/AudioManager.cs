using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectsMixer;

    public AudioSource bossDeath, bossEncounter, bossHit, coin, enemyDeath, fireBallBoss, fireBall,
        item, jump, playerHit, shot, skeletonHit, swordSlash, walk, bGMusic, bossBGMusic;

    public static AudioManager instance;

    [Range(-80,10)]
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

        musicSlider.minValue = -80;
        musicSlider.maxValue = 10;
        effectsSlider.minValue = -80;
        effectsSlider.maxValue = 10;
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
