using System.Collections.Generic;
using UnityEngine;

public class SkillTreeDynamic : MonoBehaviour
{
    private Dictionary<string, DynamicSkill> skills;
    private Dictionary<string, List<string>> prerequisites;

    void Start()
    {
        skills = new Dictionary<string, DynamicSkill>();
        prerequisites = new Dictionary<string, List<string>>();
    }

    // Add a new skill to the skill tree
    public void AddSkill(DynamicSkill newSkill, List<string> newSkillPrerequisites)
    {
        skills[newSkill.skillName] = newSkill;
        prerequisites[newSkill.skillName] = newSkillPrerequisites;
    }

    // Check if a skill is unlocked based on its prerequisites
    public bool IsSkillUnlocked(string skillName)
    {
        if (!prerequisites.ContainsKey(skillName)) return true;

        foreach (var prereq in prerequisites[skillName])
        {
            if (skills[prereq].currentLevel < RequiredLevelForUnlock())
                return false;
        }
        return true;
    }

    private int RequiredLevelForUnlock()
    {
        // Define the logic for the required level to unlock a skill
        return 1;
    }

    // Retrieve a skill by its name
    public DynamicSkill GetSkill(string skillName)
    {
        return skills.ContainsKey(skillName) ? skills[skillName] : null;
    }
}
