using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public PlayerSpriteRenderer activeRenderer;
    private DeathAnimation deathAnimation;
    public int maxHealth = 3;
    public int currentHealth;
    public int score = 0;
    public string[] accquiredPowerUps;  
    public Image[] hearts; 
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public bool invincible {get; private set;}

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeartsUI();
    }

    private void Awake()
    {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit()
    {
        if (!invincible)
        {
            if (currentHealth > 0)
            {
            currentHealth -= 1;
            UpdateHeartsUI(); // Update the UI when the player is hit

            if (currentHealth == 0)
            {
                Death();
            }
            }
        }
        
    }

    public void Death()
    {
        deathAnimation.enabled = true;
        GameManager.Instance.ResetLevel(3f);
        // Set all hearts to empty when the player dies
        currentHealth = 0;
        UpdateHeartsUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            Death();
            
        }
    }

    // Update the UI to reflect the current health
    public void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                // Display full hearts for remaining health
                hearts[i].sprite = fullHeart;
                hearts[i].enabled = true; // Ensure the image component is enabled
            }
            else
            {
                // Display empty hearts for lost health
                hearts[i].sprite = emptyHeart;
                hearts[i].enabled = true; // Ensure the image component is enabled
            }
        }
    }

    public void Invincibilty(float duration = 10f)
    {
        StartCoroutine(InvincibleAnimation(duration));

    }

    private IEnumerator InvincibleAnimation(float duration)
    {
        invincible = true;
        float elapsed = 0f;
        
        while (elapsed < duration) {
            elapsed+=Time.deltaTime;

            if (Time.frameCount % 4 == 0) {
                //activeRenderer.spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
                activeRenderer.spriteRenderer.size = new Vector2(3.5f,6f);
            }
            yield return null;
        }

        activeRenderer.spriteRenderer.color = Color.white;
        activeRenderer.spriteRenderer.size = new Vector2(2.5f, 5f);
        invincible = false;
    }
}
 