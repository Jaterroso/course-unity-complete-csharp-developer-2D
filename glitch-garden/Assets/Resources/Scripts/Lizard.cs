using UnityEngine;

public class Lizard : MonoBehaviour
{
    private Attacker attacker;

    private void Awake()
    {
        attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Pega referencias
        GameObject otherObject = other.gameObject;
        Defender defender = other.GetComponent<Defender>();

        // Ataca apenas se houver
        if (defender)
        {
            attacker.Attack(otherObject);
        }
    }
}