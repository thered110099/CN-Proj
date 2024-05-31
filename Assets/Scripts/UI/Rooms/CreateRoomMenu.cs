using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            Debug.LogError("Photon is not connected and ready for operations.");
            return;
        }

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text, options, TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room Successfully.");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room Creation Failed: " + message);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        PhotonNetwork.LoadLevel("Level 1");
    }
}
