using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Transform healthbarBar;
    public int maxHealth = 100;
    public int currentHealth;
    public bool canRegen = true;

    public bool isEnemy;

    void Awake()
    {
        currentHealth = maxHealth;
        StartCoroutine(NaturalHealthRegen());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            print("K pressed");
            TakeDamage(1);
            print("dealt 10Damage ig");
        }
        if(!isEnemy)
        {
            UpdateHealthBar();
        }
    }
    public void UpdateHealthBar()
    {
        float ratio = (float)currentHealth / maxHealth;
        healthbarBar.localScale = new Vector2(ratio, healthbarBar.localScale.y);
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