using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

    private void Update()
    {
        Move();
    }

    // Movimenta entre os pontos
    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            // Recupera posicao do waypoint e define velocidade
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = (waveConfig.GetMoveSpeed() * Time.deltaTime);

            // Anda entre a posicao atual e o destino
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}