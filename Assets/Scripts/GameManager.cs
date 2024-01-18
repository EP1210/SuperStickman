

using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
  public static GameManager Instance {get; private set;}
  public int world {get; private set;}
  public int stage {get; private set;}
  public int lives { get; private set;}

    // just creates on scene and destroy if there are more 
  // private void Awake(){
  //   if (Instance != null) {
  //       DestroyImmediate(gameObject);
  //   } else {
  //       Instance = this;
  //       DontDestroyOnLoad(gameObject);
  //   }
  // }

  private void OnDestroy() {
    if(Instance == this) {
        Instance = null;
    }
  }



  public void NewGame() {
    lives = 3;
    LoadLevel(1, 1);
  }

  public void LoadLevel(int world, int stage) {
    this.world = world;
    this.stage = stage;

    SceneManager.LoadScene($"{world}-{stage}");
  }

  public void NextLevel() {
    LoadLevel(world, stage +1);
  }

  public void ResetLevel(float delay) {
    Invoke(nameof(ResetLevel), delay);
  }

  public void ResetLevel(){
    lives -= 1;
    if (lives > 0) {
        LoadLevel(world, stage);
    } else {
        NewGame();
    }
  }

  public void SelectLevel(int level){
    LoadLevel(1,level);
  }

  public void QuitGame(){
    Application.Quit();
  }

}
