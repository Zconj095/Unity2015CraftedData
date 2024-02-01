using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int intelligence;
    public int wisdom;
    public int knowledge;
    public int agility;

    // Update skills based on player's attributes
    public void UpdateSkills(EnhancedSkill skill)
    {
        skill.intelligence = intelligence;
        skill.wisdom = wisdom;
        skill.knowledge = knowledge;

        // Adjust cooldown based on intelligence
        skill.cooldownDuration -= CooldownReduction(intelligence);
    }

    private float CooldownReduction(int intAttr)
    {
        // Define logic for cooldown reduction based on intelligence
        return intAttr * 0.05f; // Example: 5% reduction per intelligence point
    }

    // Additional methods for reaction and response time can be added here
}
