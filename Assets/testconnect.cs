using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class testconnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("Connecting to Photon...");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("Connected to Photon server.");
        // Log local player's nickname
        print("My NickName is " + PhotonNetwork.LocalPlayer.NickName);
        // Join lobby
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("Disconnected from Photon server for reason: " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        print("Joined Lobby");
    }
}
