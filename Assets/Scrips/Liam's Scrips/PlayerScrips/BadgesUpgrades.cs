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
    // add more multiplier if we want more different types of badges buffs
}

public class BadgesUpgrades : MonoBehaviour
{
    public Badges[] badges;


    public void ActivateBadge(int badgeIndex)
    {
        if (badgeIndex < 0 || badgeIndex >= badges.Length)
        {
            Debug.LogError("Invalid badge index");
            return;
        }
    }


}
