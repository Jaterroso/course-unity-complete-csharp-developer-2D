using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] private float levelExitSlowMotionFactor = 0.2f;

    // Colisao com player
    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(ExitLevel());
    }

    // Define parametros e contagem para proxima cena
    private IEnumerator ExitLevel()
    {
        Time.timeScale = levelExitSlowMotionFactor;
        yield return new WaitForSeconds(levelLoadDelay);
        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
