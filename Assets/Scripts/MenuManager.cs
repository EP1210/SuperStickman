using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int level;

    void Awake(){
        MenuManager.level = 1;
    }

    public void LoadLevel(int level) {
        //this.world = world;
        MenuManager.level = level;
        //GameManager.level = level;

        SceneManager.LoadScene($"1-{level}");
    }

    public void LoadCurrentLevel(){
        Debug.Log("Tryagain");
        SceneManager.LoadScene($"1-{MenuManager.level}");
    }

    public void LoadMainMenu(){
        Debug.Log("LOADMAINMENU");
        SceneManager.LoadScene("main_menu");
    }

    public void NextLevel() {
        Debug.Log("NEXTLVL");
        MenuManager.level = MenuManager.level+1;
        LoadLevel(MenuManager.level);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}