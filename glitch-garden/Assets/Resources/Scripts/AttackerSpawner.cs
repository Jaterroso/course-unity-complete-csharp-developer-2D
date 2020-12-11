using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] attackerPrefabArray;

    private bool spawn = true;
    private bool doneSpawning = false;

    public bool GetDoneSpawning()
    {
        return doneSpawning;
    }

    private IEnumerator Start()
    {
        // Instancia enquanto 'pode'
        while (spawn)
        {
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);
            SpawnAttacker();

            if (!spawn)
            {
                doneSpawning = true;
            }
        }
    }

    // Escolhe prefab aleatorio
    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    // Instancia prefab
    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate(myAttacker, transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Para de instanciar
    public void StopSpawning()
    {
        spawn = false;
    }
}