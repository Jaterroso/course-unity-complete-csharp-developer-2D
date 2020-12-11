using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private int numberOfAttackers = 0;
    private bool levelTimerFinished = false;

    [SerializeField] private GameObject winLabel;
    [SerializeField] private GameObject loseLabel;
    [SerializeField] private float waitToLoad = 3f;

    // Cached
    private AudioSource audioSource;
    private LevelLoader levelLoader;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    // Incrementa numero de attackers
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    // Decrementa numero de attackers
    public void AttackerKilled()
    {
        numberOfAttackers--;

        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            bool allSpawnersDone = AllSpawnersDone();

            if (allSpawnersDone)
            {
                StartCoroutine(HandleWinCondition());
            }
        }
    }

    // Indica que a fase acabou
    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    // Itera cada spawner e para de spawnar
    private void StopSpawners()
    {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawnersArray)
        {
            spawner.StopSpawning();
        }

        levelTimerFinished = true;
    }

    // Mostra texto de vitoria e exibe proxima cena
    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        audioSource.Play();
        waitToLoad = audioSource.clip.length;
        yield return new WaitForSeconds(waitToLoad * 2);
        levelLoader.LoadNextScene();
    }

    // Exibe texto de derrota
    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    // Verifica se todos os 'spawners' pararam de fato
    private bool AllSpawnersDone()
    {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();
        bool allSpawnersFinished = true;

        foreach (AttackerSpawner spawner in spawnersArray)
        {
            bool thisSpawnerFinished = spawner.GetDoneSpawning();

            if (!thisSpawnerFinished)
            {
                allSpawnersFinished = false;
            }
        }

        return allSpawnersFinished;
    }
}