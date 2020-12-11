using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject projectile;
    private AttackerSpawner myLaneSpawner;
    private GameObject projectileParent;
    private const string PROJECTILE_PARENT_NAME = "Projectiles";

    // Cached
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        SetLaneSpawner();
        CreateProjectileParent();
    }

    private void Update()
    {
        animator.SetBool("isAttacking", IsAttackerInLane());
    }

    // Cria "pai" do projetil
    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    // Prepara configuracao do spawner do inimigo
    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        // Itera cada spawner
        foreach (AttackerSpawner spawner in spawners)
        {
            // Calcula posicao
            float remainingPosition = spawner.transform.position.y - transform.position.y;
            bool isCloseEnough = (Mathf.Abs(remainingPosition) <= Mathf.Epsilon);

            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    // Define pela quantidade de filhos
    private bool IsAttackerInLane()
    {
        if (myLaneSpawner)
        {
            return (myLaneSpawner.transform.childCount > 0);
        }
        else
        {
            return false;
        }
    }

    // Atira um projetil
    public void Fire(float damage)
    {
        GameObject project = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        project.transform.parent = projectileParent.transform;
        Destroy(project, 2f);
    }
}