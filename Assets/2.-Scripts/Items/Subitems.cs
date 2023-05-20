using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subitems : MonoBehaviour
{

    public float subItemsAmount;
    public Text subItemsText;

    public static Subitems instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        subItemsText.text = subItemsAmount.ToString();
    }

    public void SubItem(float subItemAmount)
    {
        subItemsAmount += subItemAmount;
        subItemsText.text = subItemsAmount.ToString();
    }
}
