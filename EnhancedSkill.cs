using UnityEngine;

public class EnhancedSkill : MonoBehaviour
{
    public string skillName;
    public int skillLevel;
    public float cooldownDuration;
    private float lastUsedTime;

    public int intelligence; // These can be linked to player attributes
    public int wisdom;
    public int knowledge;

    // Method to enhance skill based on level and attributes
    public float GetSkillPower()
    {
        return EnhanceSkill(skillLevel, intelligence, wisdom, knowledge);
    }

    private float EnhanceSkill(int level, int intAttr, int wisAttr, int knoAttr)
    {
        // Define logic for skill enhancement
        return level * (1f + intAttr * 0.1f + wisAttr * 0.05f + knoAttr * 0.05f);
    }

    // Check if skill is ready to use based on cooldown
    public bool IsSkillReadyToUse()
    {
        return Time.time >= lastUsedTime + cooldownDuration;
    }

    // Use the skill
    public void UseSkill()
    {
        if (IsSkillReadyToUse())
        {
            lastUsedTime = Time.time;
            // Skill usage logic
        }
        else
        {
            Debug.Log("Skill on cooldown");
        }
    }

    void Update()
    {
        // Optional: Update skill behavior or effects here
    }
}
