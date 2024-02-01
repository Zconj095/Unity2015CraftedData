using System.Collections.Generic;
using UnityEngine;

public class SkillDependencyGraph : MonoBehaviour
{
    private Dictionary<string, AdvancedSkill> allSkills;
    private Dictionary<string, List<string>> skillPrerequisites;

    void Start()
    {
        allSkills = new Dictionary<string, AdvancedSkill>();
        skillPrerequisites = new Dictionary<string, List<string>>();
    }

    public void RegisterSkill(AdvancedSkill skill, List<string> prerequisites)
    {
        allSkills[skill.skillIdentifier] = skill;
        skillPrerequisites[skill.skillIdentifier] = prerequisites;
    }

    public bool CheckSkillUnlock(string skillId)
    {
        foreach (var prereq in skillPrerequisites[skillId])
        {
            if (allSkills[prereq].currentLevel < DetermineUnlockLevel())
            {
                return false;
            }
        }
        return true;
    }

    private int DetermineUnlockLevel()
    {
        // Define the logic for the required level to unlock a skill
        return 1;
    }
}
