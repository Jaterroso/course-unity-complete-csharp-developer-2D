using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Config
    [SerializeField] private float delayInSeconds = 2f;

    // Cached
    private GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
    }

    // Carrega menu de start
    public void LoadStartMenu()
    {
        if (gameSession)
        {
            gameSession.ResetGame();
        }

        SceneManager.LoadScene(0);
    }

    // Carrega fase
    public void LoadGame()
    {
        if (gameSession)
        {
            gameSession.ResetGame();
        }

        SceneManager.LoadScene("Game");
    }

    // Carrega game over
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    // Espera 'n' segundos e abre nova scene
    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game_Over");
    }

    // Fecha aplicacao
    public void QuitGame()
    {
        Application.Quit();
    }
}