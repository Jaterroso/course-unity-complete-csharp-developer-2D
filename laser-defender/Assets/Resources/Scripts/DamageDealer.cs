using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float minDamage = 100;
    [SerializeField] private float maxDamage = 100;

    public int GetDamage()
    {
        return (int)Random.Range(minDamage, maxDamage);
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}