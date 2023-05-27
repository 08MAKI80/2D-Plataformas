using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossUI : MonoBehaviour
{

    public GameObject bossPanel;
    public GameObject walls;

    public static BossUI instance;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);

    }
    public void BossActivator()
    {
        bossPanel.SetActive(true);
        walls.SetActive(true);
    }
    public void BossDesactivator()
    {
        bossPanel.SetActive(false);
        walls.SetActive(false);
    }
}
