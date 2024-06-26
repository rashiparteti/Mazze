using System.Collections;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip soundClip; // Sound clip to be played
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component on the same GameObject
        if (soundClip != null)
        {
            audioSource.clip = soundClip; // Assign the audio clip to the AudioSource
            StartCoroutine(PlaySoundRepeatedly());
        }
        else
        {
            Debug.LogWarning("Sound clip not assigned!");
        }
    }

    IEnumerator PlaySoundRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(7f); // Wait for 7 seconds
            audioSource.Play(); // Play the audio clip
        }
    }
}
