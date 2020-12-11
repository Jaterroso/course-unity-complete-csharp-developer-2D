using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFX;

    private GameObject vxfParent;
    private const string VXF_PARENT_NAME = "Visual_Effects";

    private void Start()
    {
        CreateVXFParent();
    }

    // Cria "pai" do objeto de efeitos
    private void CreateVXFParent()
    {
        vxfParent = GameObject.Find(VXF_PARENT_NAME);
        if (!vxfParent)
        {
            vxfParent = new GameObject(VXF_PARENT_NAME);
        }
    }

    // Lida com o valor de vida
    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            TriggerDeathVXF();
            Destroy(gameObject);
        }
    }

    // Lida com efeitos da morte
    private void TriggerDeathVXF()
    {
        if (!deathVFX) { return; }

        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation) as GameObject;
        deathVFXObject.transform.parent = vxfParent.transform;
        Destroy(deathVFXObject, 1f);
    }
}