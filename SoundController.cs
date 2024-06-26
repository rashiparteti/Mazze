using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class MainMenuSoundController : MonoBehaviour
{
    public AudioClip menuMusic;  // The audio clip for the menu music
    private AudioSource audioSource;  // Reference to the audio source component
    private static MainMenuSoundController instance;  // Singleton instance

    void Awake()
    {
        // Ensure only one instance of the sound controller exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keep this object persistent across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
        }
    }

    void Start()
    {
        // Add or get an AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Configure the audio source
        audioSource.clip = menuMusic;
        audioSource.loop = true;  // Loop the audio
        audioSource.playOnAwake = false;  // Do not play automatically

        // Register the scene change callback
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Check if we are starting on the main menu scene
        if (IsMainMenuScene(SceneManager.GetActiveScene().name))
        {
            PlayMenuMusic();
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the new scene is the main menu
        if (IsMainMenuScene(scene.name))
        {
            PlayMenuMusic();
        }
        else
        {
            StopMenuMusic();
        }
    }

    private bool IsMainMenuScene(string sceneName)
    {
        // Define the main menu scene name
        return sceneName == "MainMenu";  // Replace "MainMenu" with your actual scene name
    }

    private void PlayMenuMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopMenuMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void OnDestroy()
    {
        // Unregister the scene change callback
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
