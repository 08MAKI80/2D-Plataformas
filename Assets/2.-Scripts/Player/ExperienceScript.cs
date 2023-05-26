using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExperienceScript : MonoBehaviour
{
    public Image expImage;
    public float currentExp, expToNextLV;
    public int currentLV;
    public Text currentLvText;


    public static ExperienceScript instance;

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
        currentLV = 1;
        currentLvText.text = currentLV.ToString();
        expImage.fillAmount = currentExp / expToNextLV;
    }

    // Update is called once per frame
    void Update()
    {
        expImage.fillAmount = currentExp / expToNextLV;
    }

    public void expModifier(float experience)
    {

        currentExp += experience;
        expImage.fillAmount = currentExp / expToNextLV;
        if (currentExp >= expToNextLV)
        {
            expToNextLV = expToNextLV * 2;
            currentExp = 0;
            PlayerHealt.instance.maxHealth += 50f;
            PlayerHealt.instance.maxMana += 20f;
            PlayerHealt.instance.swordDamage += 5f;
            PlayerHealt.instance.bulletDamage += 3f;
            PlayerHealt.instance.spellDamage += 5f;
            currentLV++;
            currentLvText.text = currentLV.ToString();
        }
    }
}
