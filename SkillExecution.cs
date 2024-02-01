using UnityEngine;

public class SkillExecution : MonoBehaviour
{
    public float skillSpeed;
    public float playerAgility;
    public float reactionTime;
    public float responseTime;

    // Calculate Skill Execution Performance
    public float CalculateSkillExecution()
    {
        // Placeholder for actual calculation
        return skillSpeed * playerAgility - (reactionTime + responseTime);
    }
}
