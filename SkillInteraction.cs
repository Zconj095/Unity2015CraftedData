using UnityEngine;

public class SkillInteraction : MonoBehaviour
{
    public string skillName;
    public int currentLevel;
    public float currentExperience;
    public int maxLevel;
    public float experienceGrowthRate;
    internal float timing;

    public void UseSkill()
    {
        float experienceGained = CalculateExperienceGain();
        GainExperience(experienceGained);
    }

    private void GainExperience(float experience)
    {
        currentExperience += experience;
        if (currentExperience >= RequiredExperienceForLevelUp())
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentLevel++;
        currentExperience %= RequiredExperienceForLevelUp();
        // Additional effects of leveling up can be implemented here
    }

    private float CalculateExperienceGain()
    {
        // Define the logic for experience gain based on the context of usage
        return 10f; // Example value
    }

    private float RequiredExperienceForLevelUp()
    {
        return Mathf.Pow(experienceGrowthRate, currentLevel);
    }
}
