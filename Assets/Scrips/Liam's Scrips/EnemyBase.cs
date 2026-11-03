using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage;

    public virtual void Attack(GameObject target)
    {
        Health targetHealth = target.GetComponent<Health>();
        if (targetHealth != null)
        {
            targetHealth.TakeDamage(damage);
        }
    }
}
