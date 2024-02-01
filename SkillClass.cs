using UnityEngine;
public class SkillClass: MonoBehaviour 
{
    public string Name { get; private set; }
    public int Level { get; private set; }
    public float CurrentExperience { get; private set; }

    public SkillClass(string name)
    {
        Name = name;
        Level = 0;
        CurrentExperience = 0;
    }
    

    public void AddExperience(float experience)
    {
        CurrentExperience += experience;
        // Update Level based on CurrentExperience and ExperienceRequired
        // Implement the experience required growth logic here
    } 
}
