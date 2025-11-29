using UnityEngine;
public class SlimeBoss : Monster
{
    public override void TakeTurn(Character target)
    {
        Debug.Log($"{charName} กระโดดใส่!");
        target.TakeDamage(attack);
    }
}
