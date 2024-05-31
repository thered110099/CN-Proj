using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button retryButton;
    public Button exitButton;
    public AudioClip trapCollisionSound;
    public AudioClip newMusic;

    private AudioSource trapCollisionAudioSource; // Reference to the AudioSource for trap collision sound
    private AudioSource backgroundMusicAudioSource; // Reference to the AudioSource for background music

    void Start()
{
    // Get all AudioSource components on the GameObject
    AudioSource[] audioSources = GetComponents<AudioSource>();

    // Check if there are at least two AudioSource components
    if (audioSources.Length >= 2)
    {
        // Assign the AudioSource components
        trapCollisionAudioSource = audioSources[0];
        backgroundMusicAudioSource = audioSources[1];
    }
    else
    {
        // Log an error or handle the situation where there are not enough AudioSource components
        Debug.LogError("Not enough AudioSource components on the GameObject.");
    }

    gameOverPanel.SetActive(false);
    retryButton.onClick.AddListener(Retry);
    exitButton.onClick.AddListener(ExitGame);
    SetButtonsActive(false); // Initially, set buttons to inactive
}


    public void ShowGameOverPanel()
    {
        // Stop the background music
        backgroundMusicAudioSource.Stop();

        // Play the trap collision sound
        if (trapCollisionSound != null)
        {
            trapCollisionAudioSource.PlayOneShot(trapCollisionSound);
        }

        // Play the new music
        if (newMusic != null)
        {
            backgroundMusicAudioSource.clip = newMusic;
            backgroundMusicAudioSource.Play();
        }

        gameOverPanel.SetActive(true);
        SetButtonsActive(true); // Set buttons to active when showing the game over panel
        Time.timeScale = 0f;
    }

    void SetButtonsActive(bool isActive)
    {
        retryButton.gameObject.SetActive(isActive);
        exitButton.gameObject.SetActive(isActive);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}
