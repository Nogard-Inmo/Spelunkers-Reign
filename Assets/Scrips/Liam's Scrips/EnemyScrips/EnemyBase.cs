using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    public int damage;
    public float speed;
    public float attackCooldown;
    public float attackTime;
    public float attackRange;
    public Rigidbody2D rb;

    public Vector2 playerPos;

    public GameObject player;

    public NavMeshAgent agent;

    public Collider2D playerCollider;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        // Required for NavMeshPlus 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = speed;

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        playerCollider = player.GetComponent<Collider2D>();


        if (rb == null) rb = GetComponent<Rigidbody2D>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        LocatePlayer();
        MoveToPlayer();
    }

    public virtual void Attack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }
    public virtual void LocatePlayer()
    {
        playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        
    }

    public virtual void MoveToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos);
        if (distanceToPlayer < attackRange)
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
        else
        {
            agent.isStopped = false;

            agent.SetDestination(player.transform.position);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
#endif
}
