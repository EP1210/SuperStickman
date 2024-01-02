
using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    private DeathAnimation deathAnimation;
    private int initialHealth = 3;
    private int currentHealth = 0;

     void Start(){
        currentHealth = initialHealth; 
    }

    private void Awake(){
        deathAnimation = GetComponent<DeathAnimation>();
    }

  public void Hit(){
    if (currentHealth > 1){
        currentHealth -= 1;
    } else {
        Death();
    }

  }

    public void Death(){
        deathAnimation.enabled = true;
        GameManager.Instance.ResetLevel(3f);
    }

  
}
