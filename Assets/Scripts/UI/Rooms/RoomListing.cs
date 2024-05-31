using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        _text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }

    public void OnClick_Button()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinRoom(RoomInfo.Name);
            }
            else
            {
                Debug.LogError("Cannot join room. Not in a lobby.");
            }
        }
        else
        {
            Debug.LogError("Photon is not connected and ready.");
        }
    }
}
