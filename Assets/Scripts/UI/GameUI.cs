using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections; 
public class GameUI : MonoBehaviourPunCallbacks
{
    public static GameUI Instance;

    public GameObject winnerCanvas;
    public Text winnerText;
    public Text scoreText; // Added field for displaying the score
    private int highestScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        StartCoroutine(ReturnToSceneRooms());
    }

    IEnumerator ReturnToSceneRooms()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        // Return all players to the scene rooms
        PhotonNetwork.LoadLevel("Rooms");
    }

    public override void OnEnable()
    {
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this); // Register this script as a callback target for PUN
    }

    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this); // Deregister this script as a callback target for PUN
    }

    public void ShowWinner(string winnerName, int score)
    {
        winnerText.text = $"{winnerName} won with a score of {score}!";
        winnerCanvas.SetActive(true);
        Debug.Log("Winner canvas shown.");

        // Update the local score text when showing the winner
        scoreText.text = $"Your Score: {score}";
    }

    public void HideWinner()
    {
        winnerCanvas.SetActive(false);
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void SetHighestScore(int score)
    {
        highestScore = score;
    }

    // Override OnPlayerLeftRoom to handle when a player leaves the room
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"Player {otherPlayer.NickName} left the room.");

        // Perform any necessary actions when a player leaves, such as updating scores or game state
    }
}
