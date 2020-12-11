using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Configuration parameters
    [Header("Player")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float padding = 1f;
    [SerializeField] private int health = 500;
    [SerializeField] private GameObject deathVFX;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.75f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] [Range(0, 1)] private float shootSoundVolume = 0.25f;

    [Header("Projectile")]
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float projectileFiringPeriod = 0.1f;

    private Coroutine firingCoroutine;

    // Bounds
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    private Level level;

    public int GetHealth()
    {
        return health;
    }

    private void Start()
    {
        level = FindObjectOfType<Level>();
        SetUpMoveBoundaries();
    }

    private void Update()
    {
        Move();
        Fire();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        // != null . Termina o metodo
        if (!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    private void SetUpMoveBoundaries()
    {
        // Calcula limites de movimentacao do play utilizando valores da camera
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    private void Move()
    {
        // Inputs
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        // Limita posicao e calcula a mesma
        var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPosition, newYPosition);
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Arruma problema com SPACE e mouse
            if (firingCoroutine == null)
            {
                firingCoroutine = StartCoroutine(FireContinuosly());
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // Arruma problema com SPACE e mouse
            if (firingCoroutine != null)
            {
                StopCoroutine(firingCoroutine);
                firingCoroutine = null;
            }
        }
    }

    // Corrotina para atirar
    private IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D laserRb2D = laser.GetComponent<Rigidbody2D>();
            laserRb2D.velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
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

    // Morre e toca animacao com audio
    private void Die()
    {
        Destroy(gameObject);
        GameObject explosionEffect = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosionEffect, 1f);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        level.LoadGameOver();
    }
}