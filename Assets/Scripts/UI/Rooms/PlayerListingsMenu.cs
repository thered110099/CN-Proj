using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content; // Assign this in the Inspector
    [SerializeField]
    private PlayerListing playerListingPrefab; // Assign this in the Inspector

    private Dictionary<int, PlayerListing> _playerListings = new Dictionary<int, PlayerListing>();

    private void Start()
    {
        Debug.Log("PlayerListingsMenu script started.");
        // Add existing players in the room when the script starts
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddPlayerListing(player);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("Player entered room: " + newPlayer.NickName);
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        Debug.Log("Player left room: " + otherPlayer.NickName);
        RemovePlayerListing(otherPlayer);
    }

    private void AddPlayerListing(Player player)
    {
        if (!_playerListings.ContainsKey(player.ActorNumber))
        {
            Debug.Log("Adding player listing for: " + player.NickName);
            PlayerListing listing = Instantiate(playerListingPrefab, content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _playerListings.Add(player.ActorNumber, listing);
                Debug.Log("Player listing added for: " + player.NickName);
            }
            else
            {
                Debug.LogError("Failed to instantiate player listing.");
            }
        }
        else
        {
            Debug.LogWarning("Player listing already exists for: " + player.NickName);
        }
    }

    private void RemovePlayerListing(Player player)
    {
        if (_playerListings.ContainsKey(player.ActorNumber))
        {
            Debug.Log("Removing player listing for: " + player.NickName);
            Destroy(_playerListings[player.ActorNumber].gameObject);
            _playerListings.Remove(player.ActorNumber);
            Debug.Log("Player listing removed for: " + player.NickName);
        }
        else
        {
            Debug.LogWarning("No player listing found for: " + player.NickName);
        }
    }
}
