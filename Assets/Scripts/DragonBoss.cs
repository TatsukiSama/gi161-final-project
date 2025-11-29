using UnityEngine;
public class DragonBoss : Monster
{
    bool charging = false;

    public override void TakeTurn(Character target)
    {
        if (!charging)
        {
            Debug.Log($"{charName} ชาร์จพลัง!");
            charging = true;
        }
        else
        {
            Debug.Log($"{charName} พ่นไฟรุนแรง!");
            target.TakeDamage(attack + 20);
            charging = false;
        }
    }
}
