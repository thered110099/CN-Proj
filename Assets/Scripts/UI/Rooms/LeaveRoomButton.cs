using UnityEngine;
using Photon.Pun;

public class LeaveRoomButton : MonoBehaviour
{
    public GameObject lobbyCanvas;

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void ReturnToLobby()
    {
        lobbyCanvas.SetActive(true);
    }
}
