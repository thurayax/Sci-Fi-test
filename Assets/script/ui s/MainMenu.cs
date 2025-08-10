using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "GameScene";

    public void PlayGame()
    {
        Debug.Log($"[MainMenu] Loading scene: {gameSceneName}");
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("[MainMenu] Quit requested");
        Application.Quit();
    }
}
