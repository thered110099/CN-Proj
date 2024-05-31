using UnityEngine;
using UnityEngine.UI;

public class CharacterCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("End"))
        {
            DestroyCharacter();
        }
    }

    private void DestroyCharacter()
    {
        // You can add any additional logic here for character destruction
        Destroy(gameObject);

        // Call the script responsible for showing the panel
        LevelCompletePanelHandler.Instance.ShowGameOverPanel();
    }
}