using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillProgression : MonoBehaviour
{
    private Dictionary<string, SkillInteraction> skills;
    private List<string> skillPathway; // Player's current pathway through the skill tree

    void Start()
    {
        skills = new Dictionary<string, SkillInteraction>();
        skillPathway = new List<string>();
    }

    public void RegisterSkill(SkillInteraction skill)
    {
        skills[skill.skillName] = skill;
    }

    public void UseSkill(string skillName)
    {
        if (skills.ContainsKey(skillName))
        {
            skills[skillName].UseSkill();
            UpdateSkillPathway(skillName);
        }
    }

    private void UpdateSkillPathway(string skillName)
    {
        if (!skillPathway.Contains(skillName))
        {
            skillPathway.Add(skillName);
        }
    }

    public float CalculatePlayerProficiency()
    {
        float proficiency = 0f;
        foreach (var skillName in skillPathway)
        {
            proficiency += EvaluateSkillProficiency(skills[skillName]);
        }
        return proficiency;
    }

    private float EvaluateSkillProficiency(SkillInteraction skill)
    {
        // Define the logic to evaluate skill proficiency
        return skill.currentLevel; // Example calculation
    }
}
