using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int level;
    public int pointsPerLevel;
    public int availablePoints;

    public int strength;
    public int dexterity;
    public int agility;
    public int intelligence;

    void Start()
    {
        // Initialize attributes based on initial level
        CalculateInitialAttributes();
    }

    void CalculateInitialAttributes()
    {
        // Initialize attributes here based on level and any other factors
        availablePoints = level * pointsPerLevel;
        // Example initialization
        strength = 10;
        dexterity = 10;
        agility = 10;
        intelligence = 10;
    }

    public void LevelUp()
    {
        level++;
        availablePoints += pointsPerLevel;
        // Additional logic for level up can be added here
    }

    public void AllocateAttributePoints(int strPoints, int dexPoints, int agiPoints, int intPoints)
    {
        if (availablePoints >= (strPoints + dexPoints + agiPoints + intPoints))
        {
            strength += strPoints;
            dexterity += dexPoints;
            agility += agiPoints;
            intelligence += intPoints;
            availablePoints -= (strPoints + dexPoints + agiPoints + intPoints);
        }
        else
        {
            Debug.Log("Not enough points to allocate");
        }
    }

    // Additional methods to calculate the effectiveness of skills and actions based on attributes can be added here
}
