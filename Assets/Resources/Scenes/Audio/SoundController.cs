using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip mySound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mySound;
        audioSource.Play();
    }
}
