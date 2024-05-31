using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{
    [SerializeField]
    private Text playerNameText; // Assign this in the Inspector

    public void SetPlayerInfo(Player player)
    {
        if (playerNameText != null)
        {
            playerNameText.text = player.NickName;
            Debug.Log("Set player info: " + player.NickName);
        }
        else
        {
            Debug.LogError("PlayerNameText is not assigned.");
        }
    }
}
