using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int level {get; private set;}

    public void LoadLevel(int level) {
        //this.world = world;
        this.level = level;

        SceneManager.LoadScene($"1-{level}");
    }

    public void NextLevel() {
        LoadLevel(level +1);
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
