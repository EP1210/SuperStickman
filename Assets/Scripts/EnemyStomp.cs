
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyStomp : MonoBehaviour {

    //public Sprite flatSprite; falls wir nen Todes sprite erschaffen wollen

    private void OnCollisionEnter2D (Collision2D collision){

        //check if the Player collision
        if(collision.gameObject.CompareTag("Player")) {

            Player player = collision.gameObject.GetComponent<Player>();
            //check if the player jumped on the head 
            if(collision.transform.DotTest(transform, Vector2.down)) {
                
                player.score+=2;
                player.UpdateScoreUI();
                player.StartCoroutine(player.ScoreHighlights());
                Flatten();
        
            } else {
                player.Hit();
                player.score--;
                player.UpdateScoreUI();
            }

        }
    }

    private void Flatten(){
                GetComponent<Collider2D>().enabled = false;
                GetComponent<EntityMovement>().enabled = false;
                GetComponent<AnimationScript>().enabled = false;
                Destroy(gameObject, 0.5f);
    }



}
