using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the Pause Menu Canvas

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is initially disabled
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
        }
    }

    void Update()
    {
        // Check for the Escape key press to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        // Pause or resume the game based on the current pause state
        Time.timeScale = isPaused ? 0 : 1;

        // Show or hide the pause menu canvas
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isPaused);
        }
    }

    public void ResumeGame()
    {
        // Call this method when the "Resume" button is pressed
        TogglePause();
    }
}
