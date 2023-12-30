
using UnityEngine;

public class EnemyStomp : MonoBehaviour {

    //public Sprite flatSprite; falls wir nen Todes sprite erschaffen wollen

    private void OnCollisionEnter2D (Collision2D collision){

        //check if the Player collision
        if(collision.gameObject.CompareTag("Player")) {
            //check if the player jumped on the head 
            if(collision.transform.DotTest(transform, Vector2.down)) {

                GetComponent<Collider2D>().enabled = false;
                GetComponent<EntityMovement>().enabled = false;
                GetComponent<AnimationScript>().enabled = false;
                Destroy(gameObject, 0.5f);

            }

        }
    }




}
