using UnityEngine;
public class GolemBoss : Monster
{
    public override void TakeTurn(Character target)
    {
        Debug.Log($"{charName} ทุบแรง!");
        target.TakeDamage(attack + 5);
    }

    public override void TakeDamage(int dmg)
    {
        Debug.Log($"{charName} เกราะหิน ลดดาเมจครึ่งหนึ่ง!");
        base.TakeDamage(dmg / 2);
    }
}
