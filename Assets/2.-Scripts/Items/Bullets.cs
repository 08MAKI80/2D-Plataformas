using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullets : MonoBehaviour
{

    public int bulletsAmount;
    public Text bulletsText;
    public int maxBullets;

    public static Bullets instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        bulletsText.text = (bulletsAmount.ToString() + "/ " + maxBullets );
    }
    private void Update()
    {
        if (bulletsAmount > maxBullets)
        {
            bulletsAmount = maxBullets;
        }
        bulletsText.text = bulletsAmount.ToString();
    }
    public void SubItem(int subItemAmount)
    {
        bulletsAmount += subItemAmount;
        bulletsText.text = bulletsAmount.ToString();
    }
}
