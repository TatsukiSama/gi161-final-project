using UnityEngine;

public class Hero : Character
{
    public Transform attackPoint;
    public Transform shieldPoint;
    public GameObject slashEffectPrefab;
    public GameObject skillEffectPrefab;
    public GameObject shieldEffectPrefab;

    public override void TakeTurn(Character target)
    {
        Debug.Log($"{charName} โจมตี {target.charName}");
        target.TakeDamage(attack);

        SpawnSlashEffect();
    }

    public void Attack(Character target)
    {
        Debug.Log($"{charName} ใช้โจมตีปกติ");
        target.TakeDamage(attack);

        SpawnSlashEffect();
    }

    public void Guard()
    {
        Debug.Log($"{charName} ตั้งการ์ด ลดดาเมจรอบหน้า");
        defense += 15;
        Invoke(nameof(ResetDefense), 1f);

        SpawnShieldEffect();
    }

    void ResetDefense()
    {
        defense -= 15;
    }

    // Overloading Skill
    public void UseSkill(Character target)
    {
        Debug.Log($"{charName} ใช้สกิล Slash!");
        target.TakeDamage(attack + 20);

        SpawnSkillEffect();
    }

    public void UseSkill(Character target, float multiplier)
    {
        int dmg = Mathf.RoundToInt(attack * multiplier);
        Debug.Log($"{charName} ใช้สกิล STRIKE x{multiplier}");
        target.TakeDamage(dmg);
    }

    public void SpawnSlashEffect()
    {
        if (slashEffectPrefab != null && attackPoint != null)
        {
            GameObject fx = Instantiate(slashEffectPrefab, attackPoint.position, Quaternion.identity);
            Debug.Log("Effect Spawned at: " + attackPoint.position);
            Debug.Log("AttackPoint world position = " + attackPoint.position);

            Destroy(fx, 0.15f);

        }
    }

    public void SpawnSkillEffect()
    {
        if (skillEffectPrefab != null && attackPoint != null)
        {
            GameObject fx = Instantiate(skillEffectPrefab, attackPoint.position, Quaternion.identity);

            Destroy(fx, 0.4f);
        }


    }

    public void SpawnShieldEffect()
    {
        if (shieldEffectPrefab != null && shieldPoint != null)
        {
            GameObject fx = Instantiate(shieldEffectPrefab, shieldPoint.position, Quaternion.identity);

            Destroy(fx, 0.4f);
        }
    }
}


