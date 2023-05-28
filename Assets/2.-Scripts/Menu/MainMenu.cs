using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
    public void GoToMainMenu() 
    {
        SceneManager.LoadScene(0);
    }

    public void ShowSettings() 
    {
        anim.SetBool("ShowSettings", true);
    }
    public void HideSettings()
    {
        anim.SetBool("ShowSettings", false);
    }
}
