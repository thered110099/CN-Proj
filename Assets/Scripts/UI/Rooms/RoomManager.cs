using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{
    public void LoadLevelScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
