using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Stats")]
    public string charName;
    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public int defense = 2;

    protected virtual void Start()
    {
        currentHP = maxHP;
    }

    public abstract void TakeTurn(Character target);

    public virtual void TakeDamage(int dmg)
    {
        int finalDamage = Mathf.Max(dmg - defense, 0);
        currentHP -= finalDamage;

        Debug.Log($"{charName} โดน {finalDamage} ดาเมจ (HP {currentHP}/{maxHP})");

        if (currentHP <= 0)
        {
            Debug.Log($"{charName} ตายแล้ว");
        }
    }
}
