
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeAfterDelay : MonoBehaviour
{
    void Start()
    {
        // Invoke the ChangeScene method after 3 seconds
        Invoke("ChangeScene", 3f);
    }

    void ChangeScene()
    {
        // Change the scene to the desired scene name
        // Replace "YourSceneName" with the actual name of your scene
        SceneManager.LoadScene("Level 1");
    }
}
