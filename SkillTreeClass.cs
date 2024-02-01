using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
public class SkillTreeClass: MonoBehaviour
{
    private readonly Dictionary<string, Skill> skills; // Make readonly if these fields are not modified outside of constructor
    private readonly Dictionary<string, List<string>> prerequisites; // Make readonly

    public SkillTreeClass()
    {
        skills = new Dictionary<string, Skill>();
        prerequisites = new Dictionary<string, List<string>>();
    }

    public void AddSkill(Skill skill, List<string> skillPrerequisites)
    {
        skills[skill.Name] = skill; // Ensure that Skill class has a public Name property
        prerequisites[skill.Name] = skillPrerequisites;
    }

    public bool IsUnlocked(string skillName)
    {
        int requiredLevel = 1; // Placeholder value. Replace with actual logic.

        foreach (var prereq in prerequisites[skillName])
        {
            if (skills[prereq].Level < requiredLevel)
            {
                return false;
            }
        }
        return true;
    }


    // Add a method to get a Skill by name
    public Skill GetSkill(string name)
    {
        return skills.ContainsKey(name) ? skills[name] : null;
    }
}
