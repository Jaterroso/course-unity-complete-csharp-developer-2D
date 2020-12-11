using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Carrega menu principal
    public void StartMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Carrega primeira fase
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Sai do jogo
    public void QuitGame()
    {
        Application.Quit();
    }
}