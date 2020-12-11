using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float health = 100;
    [SerializeField] private int scoreValue = 100;

    [Header("Shooting")]
    [SerializeField] private float minTimeBetweenShoots = 0.2f;
    [SerializeField] private float maxTimeBetweenShoots = 3f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectibleSpeed;
    private float shotCounter;

    [Header("Visual and Sound Effects")]
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private float durationOfExplosion = 0.7f;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.75f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] [Range(0, 1)] private float shootSoundVolume = 0.25f;

    // Cached
    private GameSession gameSession;

    private void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
    }

    private void Update()
    {
        CountdownAndShoot();
    }

    // Quando colide
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        // ! = null . Termina o metodo
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    // Processa dano tomado
    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    // Quando inimigo "morre"
    private void Die()
    {
        gameSession.AddScore(scoreValue);
        Destroy(gameObject);
        GameObject explosionEffect = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        Destroy(explosionEffect, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    // Faz contagem e atira
    private void CountdownAndShoot()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShoots, maxTimeBetweenShoots);
        }
    }

    // Atira projetil
    private void Fire()
    {
        GameObject laser = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D laserRB2D = laser.GetComponent<Rigidbody2D>();
        laserRB2D.velocity = new Vector2(0, -projectibleSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }
}