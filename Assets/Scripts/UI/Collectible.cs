using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public Text scoreText; // Reference to the Text component for displaying the score
    private static int totalScore = 0; // The total score value shared among all collectibles

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScore playerScore = other.GetComponent<PlayerScore>();
            if (playerScore != null)
            {
                // Update the player's score
                playerScore.AddScore(10); // Assuming each collectible gives 10 points

                // Increase the total score by 10
                totalScore += 10;

                // Update the score text if it's not null
                if (scoreText != null)
                {
                    UpdateScoreText();
                }

                // Destroy the collectible locally
                Destroy(gameObject);
            }
        }
    }

    private void UpdateScoreText()
    {
        // Update the Text component with the current total score
        if (scoreText != null)
        {
            scoreText.text = "Score: " + totalScore.ToString();
        }
        else
        {
            Debug.LogError("scoreText is null. Please assign the Text component in the Inspector.");
        }
    }
}
