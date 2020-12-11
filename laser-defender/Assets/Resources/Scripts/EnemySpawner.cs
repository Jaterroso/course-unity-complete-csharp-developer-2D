using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] private int startingWave = 0;
    [SerializeField] private bool isLooping = false;

    private IEnumerator Start()
    {
        // Executa enquanto estiver em loop
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (isLooping);
    }

    private IEnumerator SpawnAllWaves()
    {
        // Itera pelas 'ondas'
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            // Pega 'onda' atual e inicializa e espera a corotina
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        // Itera numero de inimigos
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            // Instancia novo inimigo
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            EnemyPathing enemyPathing = newEnemy.GetComponent<EnemyPathing>();
            enemyPathing.SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}