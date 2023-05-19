using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAccount : MonoBehaviour
{
    public float bank;
    public Text bankText;

    public static BankAccount instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        bankText.text = bank.ToString();
    }

    public void Money(float cashCollected) 
    {
        bank += cashCollected;
        bankText.text = bank.ToString();
    }


}
