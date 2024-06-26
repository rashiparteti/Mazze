using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;      // Maximum health of the player
    public float currentHealth;         // Current health of the player
    public Text healthText;             // UI Text to display the current health
    public Image healthBar;             // UI Image for displaying the health bar
    public GameObject gameOverScreen;   // Reference to the Game Over Screen

    void Start()
    {
        // Initialize current health to max health
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        // Update the health UI every frame (in case health changes outside of collision)
        UpdateHealthUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);
        }
    }

    void TakeDamage(float damage)
    {
        // Decrease health by the specified damage amount
        currentHealth -= damage;

        // Ensure health does not drop below 0
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        // Optional: Add feedback for damage taken (e.g., play sound, change color)
        Debug.Log("Player took damage! Current health: " + currentHealth);

        // Check if health is 0 and handle player death (e.g., disable controls, play animation)
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    void UpdateHealthUI()
    {
        // Update the health text
        if (healthText != null)
        {
            healthText.text = "" + currentHealth;
        }

        // Update the health bar fill amount
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

    void HandleDeath()
    {
        // Handle player death (e.g., show game over screen, respawn)
        Debug.Log("Player has died!");
        ShowGameOverScreen();
        gameObject.SetActive(false); // Example: deactivate the player GameObject
    }

    void ShowGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }
}
