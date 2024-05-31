using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject canvasPanel;

    void Start()
    {
        // Deactivate the panel initially
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);
        }
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch hits the game object
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject)
                    {
                        // Toggle the panel's activation
                        if (canvasPanel != null)
                        {
                            canvasPanel.SetActive(!canvasPanel.activeSelf);
                        }
                    }
                }
            }
        }
    }
}
