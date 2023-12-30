using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
   private SpriteRenderer spriteRenderer;
   private PlayerMovement movement;
   public Sprite idle;
   public Sprite jump;
   public Sprite duck;
   public AnimationScript run;
   public Sprite slide;


   private void Awake()
   {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponent<PlayerMovement>();
   }

   private void OnEnable()
   {
        spriteRenderer.enabled = true;
   }

   private void OnDisable()
   {
        spriteRenderer.enabled = false;
   }

   private void LateUpdate()
   {
        run.enabled = movement.running;

        if (movement.jumping) {
            spriteRenderer.sprite = jump;
        }else if (movement.sliding) {
            spriteRenderer.sprite = slide;
        } else if (movement.ducking) {
            spriteRenderer.sprite = duck;
        } else if (!movement.running && !movement.jumping) {
            spriteRenderer.sprite = idle;
        }
   }
}