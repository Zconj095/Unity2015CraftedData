using UnityEngine;

public class AdvancedSkill : MonoBehaviour
{
    public string skillIdentifier;
    public int currentLevel;
    public float accumulatedExperience;
    public int maximumLevel;
    public float baseExperienceGrowth;

    public void GainExperience(float experience)
    {
        if (currentLevel >= maximumLevel) return;

        accumulatedExperience += experience;
        while (accumulatedExperience >= RequiredExperience() && currentLevel < maximumLevel)
        {
            accumulatedExperience -= RequiredExperience();
            currentLevel++;
        }
    }

    private float RequiredExperience()
    {
        return Mathf.Pow(baseExperienceGrowth, currentLevel);
    }
}
