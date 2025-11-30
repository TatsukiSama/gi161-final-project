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
        AddMP(10);  // โจมตีได้มานา 10

        SpawnSlashEffect();
    }

    public void Attack(Character target)
    {
        Debug.Log($"{charName} ใช้โจมตีปกติ");
        target.TakeDamage(attack);
        AddMP(10);  // ได้มานา 10

        SpawnSlashEffect();
    }

    public void Guard()
    {
        Debug.Log($"{charName} ตั้งการ์ด ลดดาเมจรอบหน้า");
        defense += 15;
        AddMP(5);   // Guard ได้ 5 มานา
        Invoke(nameof(ResetDefense), 1f);

        SpawnShieldEffect();
    }

    private void ResetDefense()
    {
        defense -= 15;
        if (defense < 0) defense = 0;
    }

    //void ResetDefense()
    //{
    //    defense -= 15;
    //}

    // Overloading Skill
    //public void UseSkill(Character target)
    //{
    //    if (!UseMP(20)) // ตรวจค่า MP
    //    {
    //        Debug.Log($"{charName} ใช้สกิลไม่สำเร็จ เพราะมานาไม่พอ");
    //        return;
    //    }

    //    Debug.Log($"{charName} ใช้สกิล Slash!");
    //    target.TakeDamage(attack + 20);

    //    SpawnSkillEffect();
    //}

    //public void UseSkill(Character target, float multiplier)
    //{
    //    if (!UseMP(20))
    //    {
    //        Debug.Log($"{charName} ใช้สกิล STRIKE ไม่สำเร็จ เพราะมานาไม่พอ");
    //        return;
    //    }

    //    int dmg = Mathf.RoundToInt(attack * multiplier);
    //    Debug.Log($"{charName} ใช้สกิล STRIKE x{multiplier}");
    //    target.TakeDamage(dmg);
    //}

    public bool TryUseSkill(Character target)
    {
        if (!UseMP(20)) // ตรวจค่า MP
        {
            Debug.Log($"{charName} ใช้สกิลไม่สำเร็จ เพราะมานาไม่พอ");
            return false; // บอก GameManager ว่าเทิร์นยังไม่จบ
        }

        Debug.Log($"{charName} ใช้สกิล Slash!");
        target.TakeDamage(attack + 20);

        return true;
    }

    // Overload Skill
    public bool TryUseSkill(Character target, float multiplier)
    {
        if (!UseMP(20))
        {
            Debug.Log($"{charName} ใช้สกิล STRIKE ไม่สำเร็จ เพราะมานาไม่พอ");
            return false;
        }

        int dmg = Mathf.RoundToInt(attack * multiplier);
        Debug.Log($"{charName} ใช้ STRIKE x{multiplier}");
        target.TakeDamage(dmg);

        return true;
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


