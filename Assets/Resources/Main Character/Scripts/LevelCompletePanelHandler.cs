using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompletePanelHandler : MonoBehaviour
{
    public static LevelCompletePanelHandler Instance; // Singleton instance

    public GameObject gameOverPanel;
    public Button retryButton;
    public Button nextButton;
    public Button exitButton;

    public AudioClip panelActivationSound; // Add an AudioClip variable
    private AudioSource panelAudioSource;

    public AudioSource backgroundMusic; // Reference to the background music AudioSource

    public void Awake()
    {
        // Singleton pattern to ensure only one instance of this script exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        panelAudioSource = GetComponent<AudioSource>(); // Initialize the AudioSource

        gameOverPanel.SetActive(false);
        retryButton.onClick.AddListener(Retry);
        nextButton.onClick.AddListener(LoadNextLevel);
        exitButton.onClick.AddListener(ExitGame);
        SetButtonsActive(false); // Initially, set buttons to inactive
    }

    public void ShowGameOverPanel()
    {
        // Stop the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }

        // Play the panel activation sound
        if (panelActivationSound != null)
        {
            panelAudioSource.PlayOneShot(panelActivationSound);
        }

        gameOverPanel.SetActive(true);
        SetButtonsActive(true); // Set buttons to active when showing the game over panel
        Time.timeScale = 0f;
    }

    void SetButtonsActive(bool isActive)
    {
        retryButton.gameObject.SetActive(isActive);
        nextButton.gameObject.SetActive(isActive);
        exitButton.gameObject.SetActive(isActive);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.LogWarning("No more levels in build index.");
        }
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu"); // Replace "MainMenu" with the name of your main menu scene
    }
}
