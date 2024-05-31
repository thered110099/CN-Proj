using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class EndObject : MonoBehaviour
{
    public GameUI gameUI; // Reference to the GameUI script
    public Text winnerText;
    public Text scoreText;

    private void Start()
    {
        winnerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerScore playerScore = collision.collider.GetComponent<PlayerScore>();
            if (playerScore != null && collision.collider.GetComponent<PhotonView>().IsMine)
            {
                int score = playerScore.GetScore(); // Assuming you have a method to get the score
                if (score > gameUI.GetHighestScore())
                {
                    gameUI.SetHighestScore(score);
                    gameUI.ShowWinner(collision.collider.GetComponent<PhotonView>().Owner.NickName, score);
                }
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}
