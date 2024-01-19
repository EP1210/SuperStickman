using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Rubber,
        Tipex,
        OpaqueWhite
    }

    float elapsed;
    float time= 10f;
    public Type type;

    private void OnTriggerEnter2D(Collider2D other){if (other.CompareTag("Player")) {Collect(other.gameObject);}}

    private void Collect(GameObject _player)
    {
        Player player = _player.GetComponent<Player>();
        PlayerMovement movement = _player.GetComponent<PlayerMovement>();

        switch (type)
        {
            case Type.Rubber:
                if (player.currentHealth<3) {
                    player.currentHealth++;
                    player.UpdateHeartsUI();
                }
                movement.maxJumpHeight = 7f;
                // StartCoroutine(RubberTimer(movement));
                break;
            case Type.Tipex:
                movement.movementSpeed = 12f;
                // StartCoroutine(TipexTimer(movement));
                break;
            case Type.OpaqueWhite:
                player.Invincibilty();
                break;
        }

        Destroy(gameObject);
    }

    /* trying to set timer for rubber/tipex effects duration -> under construction
    private IEnumerator RubberTimer(PlayerMovement movement)
    {
    float elapsed = 0f;
    while (elapsed < time)
    {
    elapsed += Time.deltaTime;
    yield return null; 
    }
    movement.maxJumpHeight = 5f;
    }

    // timer for the duration that the tipex power-up is active when collected by the player -> under construction
    private IEnumerator TipexTimer(PlayerMovement movement)
    {
    float elapsed = 0f;
    while (elapsed < time)
    {
    elapsed += Time.deltaTime;
    yield return null; 
    }
    movement.movementSpeed = 8f;
    }
    */
}
