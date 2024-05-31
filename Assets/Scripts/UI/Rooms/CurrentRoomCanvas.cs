using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
public class CurrentRoomCanvas : MonoBehaviour
{
    private RoomsCanvases _roomsCanvases;

    public void FirstInitialize(RoomsCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }

}