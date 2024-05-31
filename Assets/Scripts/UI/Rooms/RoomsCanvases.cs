using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createOrJoinRoomCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas { get { return _createOrJoinRoomCanvas;} }

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas { get { return _currentRoomCanvas;} }

    [SerializeField]
    private RoomManager _roomManager;

    private void Awake()
    {
        // Automatically assign references if not already assigned
        if (_createOrJoinRoomCanvas == null)
        {
            _createOrJoinRoomCanvas = FindObjectOfType<CreateOrJoinRoomCanvas>();
        }
        if (_currentRoomCanvas == null)
        {
            _currentRoomCanvas = FindObjectOfType<CurrentRoomCanvas>();
        }

        FirstInitialize();
    }

    private void FirstInitialize()
    {
        if (_createOrJoinRoomCanvas != null)
        {
            _createOrJoinRoomCanvas.FirstInitialize(this);
        }
        else
        {
            Debug.LogError("_createOrJoinRoomCanvas is not assigned and could not be found.");
        }

        if (_currentRoomCanvas != null)
        {
            _currentRoomCanvas.FirstInitialize(this);
        }
        else
        {
            Debug.LogError("_currentRoomCanvas is not assigned and could not be found.");
        }
    }
}
