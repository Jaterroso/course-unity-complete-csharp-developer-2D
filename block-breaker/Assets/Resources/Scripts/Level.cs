using UnityEngine;

public class Level : MonoBehaviour
{
    // Serializable to debugging process
    [SerializeField] private int breakableBlocks;

    // Cached component references
    private SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Inicializa quantidade de blocos iniciais
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    // Descrementa quantidade de blocos e muda de fase
    public void BlockDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}