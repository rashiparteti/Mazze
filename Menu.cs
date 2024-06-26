using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioClip playButtonSound;  // Sound to play when the play button is hit
    private AudioSource audioSource;  // Reference to the AudioSource component

    void Start()
    {
        // Get or add an AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void Play()
    {
        // Play the sound effect for the play button
        if (playButtonSound != null)
        {
            audioSource.PlayOneShot(playButtonSound);
        }

        // Start the coroutine to load the next scene after the sound has played
        StartCoroutine(LoadSceneAfterSound("Main"));
    }

    private IEnumerator LoadSceneAfterSound(string sceneName)
    {
        // Wait for the sound to finish playing
        yield return new WaitForSeconds(playButtonSound.length);

        // Load the next scene (assuming it's the game scene)
        SceneManager.LoadScene(sceneName);
    }
}
