using UnityEngine;

[System.Serializable]
public class SwordSkill: MonoBehaviour
{
    public string skillName;
    public float speed; // S(s)
    public float timing; // T(s)
    public float impactPower; // P(s)

    public SwordSkill(string name, float speed, float timing, float impactPower)
    {
        this.skillName = name;
        this.speed = speed;
        this.timing = timing;
        this.impactPower = impactPower;
    }
}
