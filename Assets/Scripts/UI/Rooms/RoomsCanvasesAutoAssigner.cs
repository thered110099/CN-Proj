using UnityEngine;

public class RoomsCanvasesAutoAssigner : MonoBehaviour
{
    [SerializeField] private CreateRoomMenu _createRoomMenu;

    private void Start()
    {
        // Find the RoomsCanvases GameObject in the scene
        GameObject roomsCanvasesObject = GameObject.FindWithTag("RoomsCanvases");

        if (roomsCanvasesObject != null)
        {
            // Get the RoomsCanvases component from the GameObject
            RoomsCanvases roomsCanvases = roomsCanvasesObject.GetComponent<RoomsCanvases>();

            if (roomsCanvases != null)
            {
                // Assign the RoomsCanvases component to the CreateRoomMenu script
                _createRoomMenu.FirstInitialize(roomsCanvases);
            }
            else
            {
                Debug.LogError("RoomsCanvases component not found on GameObject with tag 'RoomsCanvases'.");
            }
        }
        else
        {
            Debug.LogError("GameObject with tag 'RoomsCanvases' not found in the scene.");
        }
    }
}
