using UnityEngine;

public class Hero : Character
{
    public override void TakeTurn(Character target)
    {
        Debug.Log($"{charName} โจมตี {target.charName}");
        target.TakeDamage(attack);
    }

    public void Attack(Character target)
    {
        Debug.Log($"{charName} ใช้โจมตีปกติ");
        target.TakeDamage(attack);
    }

    public void Guard()
    {
        Debug.Log($"{charName} ตั้งการ์ด ลดดาเมจรอบหน้า");
        defense += 5;
        Invoke(nameof(ResetDefense), 1f);
    }

    void ResetDefense()
    {
        defense -= 5;
    }

    // Overloading Skill
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


