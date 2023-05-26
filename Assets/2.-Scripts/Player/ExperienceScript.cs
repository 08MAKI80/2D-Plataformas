using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ExperienceScript : MonoBehaviour
{
    public Image expImage;
    public float currentExp, expToNextLV;

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
        expImage.fillAmount = currentExp / expToNextLV;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void expModifier(float experience)
    {

        currentExp += experience;
        expImage.fillAmount = currentExp / expToNextLV;
        if (currentExp >= expToNextLV)
        {
            expToNextLV = expToNextLV * 2;
            currentExp = 0;
        }
    }
}
