using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float minSpeedOfSpin = 100f;
    [SerializeField] private float maxSpeedOfSpin = 1000f;

    private void Update()
    {
        // Rotaciona em valores aleatorios
        float speedOfSpin = Random.Range(minSpeedOfSpin, maxSpeedOfSpin);
        transform.Rotate(0, 0, speedOfSpin * Time.deltaTime);
    }
}
