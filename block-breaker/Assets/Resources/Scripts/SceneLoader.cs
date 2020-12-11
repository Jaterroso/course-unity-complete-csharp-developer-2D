using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameSession gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameSession>();
    }

    // Loads the next scene based on currentSceneIndex + 1
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Load the first scene
    public void LoadStartScene()
    {
        gameStatus.ResetGame();
        SceneManager.LoadScene(0);
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}