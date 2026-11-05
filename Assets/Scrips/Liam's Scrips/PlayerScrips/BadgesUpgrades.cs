using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Badges
{
    public string badgeName;
    public string tooltip;
    public TMP_Text tooltipBox;
    public Image badgeImage;

    public float ammoMultiplier = 1f;
    public float reloadSpeed = 1f;
    public float regenAmountMultiplier = 1f;
    public float maxHealthMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;
    public int amountOfBadges = 0;
    public int amountOfBadgesEquipped = 0;
    // add more multiplier if we want more different types of badges buffs
}

public class BadgesUpgrades : MonoBehaviour
{
    public Badges[] badges;
    public int badgeSlots = 3; // Number of badge slots available for the player

    public void ActivateBadge(int badgeIndex)
    {
        if (badgeIndex < 0 || badgeIndex >= badges.Length)
        {
            Debug.LogError("Invalid badge index");
            return;
        }
        if (badges[badgeIndex].amountOfBadges > 0 && badges[badgeIndex].amountOfBadgesEquipped < badgeSlots)
        {
            PlayerStats playerStats = GetComponent<PlayerStats>();
            playerStats.ammoMultiplier *= badges[badgeIndex].ammoMultiplier;
            playerStats.reloadSpeed *= badges[badgeIndex].reloadSpeed;
            playerStats.regenAmountMultiplier *= badges[badgeIndex].regenAmountMultiplier;
            playerStats.maxHealthMultiplier *= badges[badgeIndex].maxHealthMultiplier;
            playerStats.damageMultiplier *= badges[badgeIndex].damageMultiplier;

            // Decrease the amount of this badge
            badges[badgeIndex].amountOfBadges--;
            // Increase the amount of this badge equipped
            badges[badgeIndex].amountOfBadgesEquipped++;
        }
        else
        {
            Debug.Log("No more badges of this type left to activate.");
        }
    }


}
