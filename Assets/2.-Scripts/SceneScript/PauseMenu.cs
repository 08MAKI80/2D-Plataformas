using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    public static PauseMenu instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetButtonDown("Cancel") && !isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;
        }else if(Input.GetButtonDown("Cancel") && isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }
}
