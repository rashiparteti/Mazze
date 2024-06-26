using UnityEngine;

public class LevelCompletionTrigger : MonoBehaviour
{
    public GameObject nextlevelScreen; // Reference to the next level screen UI
    public GameObject endpoint;        // Reference to the endpoint GameObject

    void Start()
    {
        // Ensure the next level screen is hidden at the start
        if (nextlevelScreen != null)
        {
            nextlevelScreen.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        // Check if the player has collided with the endpoint
        if (collider.gameObject == endpoint)
        {
            ShowNextLevelScreen();
        }
    }

    void ShowNextLevelScreen()
    {
        // Activate the next level screen
        if (nextlevelScreen != null)
        {
            nextlevelScreen.SetActive(true);
        }
    }
}
