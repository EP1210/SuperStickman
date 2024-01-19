using System.Collections;
using System.Linq;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        Rubber,
        Tipex,
        OpaqueWhite
    }

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
                player.hasRubber = true;
                //StartCoroutine(RubberTimer(_player));
                // StartCoroutine(RubberTimer(movement));
                break;
            case Type.Tipex:
                movement.movementSpeed = 12f;
                player.hasTipex = true;
                // StartCoroutine(TipexTimer(movement));
                break;
            case Type.OpaqueWhite:
                player.UpdateInvicibleUI();
                player.Invincibilty();
                break;
        }

        Destroy(gameObject);
    }

    /* 
    // trying to set timer for rubber/tipex effects duration -> under construction
    private IEnumerator RubberTimer(GameObject _player)
    {
        PlayerMovement movement = _player.GetComponent<PlayerMovement>();
        movement.maxJumpHeight = 7f;
        float elapsed = 0f;
        float time = 2f;
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
