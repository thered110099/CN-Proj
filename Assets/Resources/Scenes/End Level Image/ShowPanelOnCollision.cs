using UnityEngine;
using UnityEngine.UI;

public class ShowPanelOnCollision : MonoBehaviour
{
    public GameObject canvasPanel;
    public Text textComponent;
    public AudioClip panelActivationSound; // Add an AudioClip variable for the panel activation sound
    public AudioClip newMusic;

    private AudioSource panelAudioSource; // Change this to panelAudioSource
    public AudioSource backgroundMusic; // Add this variable

    private void Start()
    {
        // Attempt to find AudioSource on the specified GameObject
        panelAudioSource = GetComponentInParent<AudioSource>();

        if (panelAudioSource == null)
        {
            // If AudioSource component is not found, log a warning
            Debug.LogWarning("AudioSource component not found on the parent GameObject.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("End"))
        {
            StopBackgroundMusic();
            PlayNewMusic();
            ShowPanel();
        }
    }

    private void ShowPanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(true);

            if (textComponent == null)
            {
                textComponent = canvasPanel.GetComponentInChildren<Text>();
            }

            if (textComponent != null)
            {
                textComponent.gameObject.SetActive(true);

                Animator animator = textComponent.GetComponent<Animator>();
                if (animator != null)
                {
                    animator.SetTrigger("ShowAnimation");
                }
            }
            else
            {
                Debug.LogWarning("Text component not found within the canvasPanel.");
            }
        }
        else
        {
            Debug.LogWarning("Canvas Panel not assigned to ShowPanelOnCollision script.");
        }
    }

    private void StopBackgroundMusic()
    {
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Stop();
        }
    }

    private void PlayNewMusic()
    {
        if (panelAudioSource != null && newMusic != null)
        {
            panelAudioSource.clip = newMusic;
            panelAudioSource.Play();
        }
    }
}
