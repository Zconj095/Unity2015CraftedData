using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName;
    public int initialSkillLevel;
    public float skillGainPerLevel;
    public float currentExperience;
    public float experienceRequired;

    // Method to add experience to the skill
    public void AddExperience(float experience)
    {
        currentExperience += experience;
    }

    // Method to calculate the current skill level
    public int GetSkillLevel()
    {
        return initialSkillLevel + (int)(currentExperience / experienceRequired * skillGainPerLevel);
    }

    // Optional: Method to increase the experience required for the next level
    public void IncreaseExperienceRequired(float multiplier)
    {
        experienceRequired *= multiplier;
    }
    public string Name { get; private set; } // Ensure this property exists
    public int Level { get; private set; }
    // ... other properties and methods ...

    public Skill(string name)
    {
        Name = name;
        // ... other initializations ...
    }

}
