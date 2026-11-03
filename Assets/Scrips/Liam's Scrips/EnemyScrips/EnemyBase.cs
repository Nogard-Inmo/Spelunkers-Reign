using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;
    public float speed;
    [SerializeField] Rigidbody2D rb;

    Vector2 playerPos;

    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        LocatePlayer();
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
        MoveToPlayer();
    }

    public virtual void MoveToPlayer()
    {
        rb.MovePosition(Vector2.MoveTowards(rb.position, playerPos, speed * Time.deltaTime));
    }
}
