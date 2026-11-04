using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class DroneEnemy : EnemyBase
{
    [SerializeField] private LayerMask canCollideWith;

    [Header("Combat")]
    [SerializeField] private float shootDistance = 6f;

    private void Update()
    {
        attackCooldown -= Time.deltaTime;

        if (attackCooldown < 0)
            attackCooldown = 0;

        LocatePlayer();
        MoveToPlayer();

        if (Vector2.Distance(transform.position, playerPos) <= shootDistance)
        {
            Shoot();
        }
    }

    public override void MoveToPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerPos);

        bool hasLOS = HasLineOfSight();

        // Stop if we can already shoot
        if (distanceToPlayer <= shootDistance && hasLOS)
        {
            agent.isStopped = true;
            agent.ResetPath();
            return;
        }
            agent.isStopped = false;
    }

    private bool HasLineOfSight()
    {
        Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;

        float distance =Vector2.Distance(transform.position, player.transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, canCollideWith);

        if (hit.collider == null)
            return false;

        return hit.collider == playerCollider;
    }

    private void Shoot()
    {
        if (attackCooldown > 0)
            return;

        if (!HasLineOfSight())
            return;

        attackCooldown = attackTime;
        Attack(player);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootDistance);
    }
#endif
}