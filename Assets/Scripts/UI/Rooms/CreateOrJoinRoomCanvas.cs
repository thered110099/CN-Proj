using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private RoomListingsMenu _roomListingsMenu;
    private RoomsCanvases _roomsCanvases;
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;

    private void Awake()
    {
        // Automatically assign references if not already assigned
        if (_roomListingsMenu == null)
        {
            _roomListingsMenu = FindObjectOfType<RoomListingsMenu>();
            if (_roomListingsMenu != null)
            {
                Debug.Log("Automatically assigned RoomListingsMenu.");
            }
            else
            {
                Debug.LogError("RoomListingsMenu component not found in the scene.");
            }
        }

        if (_createRoomMenu == null)
        {
            _createRoomMenu = FindObjectOfType<CreateRoomMenu>();
            if (_createRoomMenu != null)
            {
                Debug.Log("Automatically assigned CreateRoomMenu.");
            }
            else
            {
                Debug.LogError("CreateRoomMenu component not found in the scene.");
            }
        }
    }

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;

        if (_createRoomMenu != null)
        {
            _createRoomMenu.FirstInitialize(canvases);
        }

        if (_roomListingsMenu != null)
        {
            _roomListingsMenu.FirstInitialize(canvases);
        }
    }

    public void LoadLevelScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
