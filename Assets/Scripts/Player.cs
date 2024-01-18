using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private DeathAnimation deathAnimation;
    private int maxHealth = 3;
    private int currentHealth;
    public int score = 0;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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
    private void UpdateHeartsUI()
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
}
