using UnityEngine;

public class Hero : Character
{
    public override void TakeTurn(Character target)
    {
        // แบบง่าย: โจมตีปกติไปก่อน
        Debug.Log($"{charName} โจมตี {target.charName}");
        target.TakeDamage(attack);
    }

    // Overloading
    public void UseSkill(Character target)
    {
        Debug.Log($"{charName} ใช้สกิล Slash!");
        target.TakeDamage(attack + 10);
    }

    public void UseSkill(Character target, float multiplier)
    {
        int dmg = Mathf.RoundToInt(attack * multiplier);
        Debug.Log($"{charName} ใช้สกิล STRIKE x{multiplier}");
        target.TakeDamage(dmg);
    }
}
