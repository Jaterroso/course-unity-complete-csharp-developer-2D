using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    private int startingSceneIndex;

    private void Awake () 
    {
        SetupSingleton ();
    }

    private void Start ()
    {
        startingSceneIndex = SceneManager.GetActiveScene ().buildIndex;
    }

    private void Update ()
    {
        // Destroi objetos caso for fase diferente
        int currentSceneIndex = SceneManager.GetActiveScene ().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
        {
            Destroy (gameObject);
        }
    }

    private void SetupSingleton()
    {
        int numberOfScenePersists = FindObjectsOfType<ScenePersist>().Length;

        if (numberOfScenePersists > 1)
        {
            Destroy (gameObject);
        }
        else 
        {
            DontDestroyOnLoad (gameObject);
        }
    }
}