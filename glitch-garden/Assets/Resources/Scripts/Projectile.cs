using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Transform parameters")]
    private float minSpeed = 2f;
    private float maxSpeed = 8f;
    private float minRotation = 1500f;
    private float maxRotation = 3000f;

    [SerializeField] private float damage = 50f;

    private void Update()
    {
        // Escolhe valor randomico
        float speed = Random.Range(minSpeed, maxSpeed);
        float rotation = Random.Range(minRotation, maxRotation);

        // Movimenta e rotaciona
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.forward, rotation * Time.deltaTime, Space.World);
    }

    // Define ataque e destruicao
    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}