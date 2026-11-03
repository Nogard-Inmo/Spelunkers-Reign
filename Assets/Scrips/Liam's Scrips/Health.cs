using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool canRegen = true;


    void Awake()
    {
        currentHealth = maxHealth;
        StartCoroutine(NaturalHealthRegen());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
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


    void Die()
    {
        // Handle death (e.g., play animation, destroy object)
        Destroy(gameObject);
    }
    IEnumerator NaturalHealthRegen()
    {
        while (canRegen)
        {
            yield return new WaitForSeconds(5f); // Wait for 5 seconds
            if (currentHealth < maxHealth)
            {
                currentHealth += 1; // Regenerate 1 health point
                if (currentHealth > maxHealth)
                    currentHealth = maxHealth; // Ensure health doesn't exceed max
            }
        }
    }

}