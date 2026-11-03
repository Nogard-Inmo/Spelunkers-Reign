using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool canRegen = true;

    public Sprite[] healthSprites;
    public Image displayimage;
    public GameObject combatant;



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
            TakeDamage(10);
            print("dealt 10Damage ig");
        }

        if (combatant == null || displayimage == null || healthSprites == null || healthSprites.Length == 0) return; // om combatant, displayimage eller healthSprites inte är korrekt inställda, returnera och gör inget.


        float ratio = Mathf.Clamp01((float)currentHealth / Mathf.Max(1f, maxHealth)); // beräkna hälsan som en ratio mellan 0 och 1, där maxHealth inte kan vara mindre än 1.


        int index = Mathf.RoundToInt(ratio * (healthSprites.Length - 1)); // beräkna indexet för healthSprites baserat på hälsan, där 0 är full hälsa och healthSprites.Length - 1 är ingen hälsa.
        index = Mathf.Clamp(index, 0, healthSprites.Length - 1); // säkerställ att indexet är inom giltiga gränser för healthSprites arrayen.

        displayimage.sprite = healthSprites[healthSprites.Length - 1 - index]; // uppdatera displayimage med den korrekta sprite baserat på combatantens hälsa.
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