using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private int timeToWait = 4;
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Espera e carrega tela de Start
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    // Espera 'n' segundos e carrega a proxima cena
    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    // Reseta a cena
    public void RestartScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1;
    }

    // Carrega a proxima cena
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Carrega cena de perda
    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose_Screen");
    }

    // Carrega cena de start
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Start_Screen");
        Time.timeScale = 1;
    }

    // Carrega cena de opcoes
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options_Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}