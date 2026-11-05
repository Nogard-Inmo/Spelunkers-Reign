using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ImpactGrenade : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float launchForce = 15f;

    [Header("Explosion")]
    [SerializeField] private float explosionRadius = 3f;
    [SerializeField] private LayerMask damageLayers;
    GameObject player;
    PlayerStats playerStats;
    public int grenadeDamageMultiplier = 2;

    [Header("Effects")]
    [SerializeField] private GameObject explosionEffect;

    private Rigidbody2D rb;
    private bool exploded;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(direction.normalized * launchForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (exploded)
            return;

        Explode();
    }

    private void Explode()
    {
        exploded = true;

        // Visual effect
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Find all targets in radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, damageLayers);

        foreach (Collider2D hit in hits)
        {
            Health health = hit.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(playerStats.damage*grenadeDamageMultiplier);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}