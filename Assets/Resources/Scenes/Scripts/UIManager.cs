using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class UIManager : MonoBehaviour
{
    public GameObject initialPanel;
    public GameObject levelPanel;
    public Button startButton;
    public Button backButton;

    // Other images and buttons in the level panel
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;

    public Image image1;
    public Image image2;
    public Image image3;
    public void OnCreateGameButtonClick()
    {
        // Load the room creation scene
        SceneManager.LoadScene("RoomCreationScene");
    }
    private void Start()
    {
        // Enable the initial panel at the start
        initialPanel.SetActive(true);

        // Disable the level panel
        levelPanel.SetActive(false);

        // Disable the back button initially
        backButton.interactable = false;

        // Disable level buttons initially
        level1Button.interactable = false;
        level2Button.interactable = false;
        level3Button.interactable = false;

        // Attach your level buttons to their respective methods
        level1Button.onClick.AddListener(() => OnLevelButtonClick("Level 1"));
        level2Button.onClick.AddListener(() => OnLevelButtonClick("Level 2"));
        level3Button.onClick.AddListener(() => OnLevelButtonClick("Level 3"));

        // Initially, set the images to be inactive
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        // Disable the initial panel
        initialPanel.SetActive(false);

        // Enable the level panel
        levelPanel.SetActive(true);

        // Enable the back button
        backButton.interactable = true;

        // Enable level buttons
        level1Button.interactable = true;
        level2Button.interactable = true;
        level3Button.interactable = true;

        // Activate the images
        image1.gameObject.SetActive(true);
        image2.gameObject.SetActive(true);
        image3.gameObject.SetActive(true);
    }

    public void OnBackButtonClick()
    {
        // Disable the level panel
        levelPanel.SetActive(false);

        // Enable the initial panel
        initialPanel.SetActive(true);

        // Disable the back button
        backButton.interactable = false;

        // Disable level buttons
        level1Button.interactable = false;
        level2Button.interactable = false;
        level3Button.interactable = false;

        // Deactivate the images
        image1.gameObject.SetActive(false);
        image2.gameObject.SetActive(false);
        image3.gameObject.SetActive(false);
    }

    public void OnLevelButtonClick(string levelName)
    {
        // Start the loading scene
        SceneManager.LoadScene("Loading");

        // Start loading the specified level asynchronously
        StartCoroutine(LoadLevelAsync(levelName));
    }

    private IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        // Wait until the level is fully loaded
        while (!asyncLoad.isDone)
        {
            // You can update a loading progress bar here if needed
            yield return null;
        }
    }
}
