using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;


    void Awake()
    {
        currentHealth = maxHealth;
        
    }
    public virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Debug.LogWarning("Damage cannot be negative.");
            return;
        }
        if(currentHealth - damage < 0)
            currentHealth = 0;

        else
            currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {

        // Handle death (e.g., play animation, destroy object)
        Destroy(gameObject);
    }
}