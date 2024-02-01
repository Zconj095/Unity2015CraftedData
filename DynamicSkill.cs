using UnityEngine;

public class DynamicSkill : MonoBehaviour
{
    public string skillName;
    public int currentLevel;
    public float currentExperience;
    public int maxLevel;
    public float baseExperienceGrowth;

    // Add experience to the skill
    public void AddExperience(float experience)
    {
        if (currentLevel >= maxLevel) return;

        currentExperience += experience;
        LevelUp();
    }

    // Level up the skill based on current experience
    private void LevelUp()
    {
        while (currentExperience >= RequiredExperience() && currentLevel < maxLevel)
        {
            currentExperience -= RequiredExperience();
            currentLevel++;
        }
    }

    // Calculate the required experience for the next level
    private float RequiredExperience()
    {
        return Mathf.Pow(baseExperienceGrowth, currentLevel);
    }
}
