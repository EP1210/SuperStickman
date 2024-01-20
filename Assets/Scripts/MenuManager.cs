using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static int level;

    public void LoadLevel(int level) {
        //this.world = world;
        MenuManager.level = level;
        //GameManager.level = level;

        SceneManager.LoadScene($"1-{level}");
    }

    public void LoadCurrentLevel(){
        SceneManager.LoadScene($"1-{MenuManager.level}");
    }

    public void NextLevel() {
        LoadLevel(MenuManager.level +1);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
