using UnityEngine;
public class DragonBoss : Monster
{
    public Transform dragonPoint;
    public GameObject BeamEffectPrefab;

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

            SpawnDragonEffect();
        }
    }

    public void SpawnDragonEffect()
    {
        if (BeamEffectPrefab != null && dragonPoint != null)
        {
            
            GameObject fx = Instantiate(BeamEffectPrefab, dragonPoint.position, Quaternion.identity);
            fx.transform.Rotate(0, 0, 30);

            Destroy(fx, 0.4f);
        }
    }
}
    